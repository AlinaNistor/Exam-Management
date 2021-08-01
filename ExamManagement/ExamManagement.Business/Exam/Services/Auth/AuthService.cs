using AutoMapper;
using CSharpFunctionalExtensions;
using Entities;
using ExamManagement.Business.Exam.Models;
using ExamManagement.Business.Exam.Models.Auth;
using ExamManagement.Business.Exam.Services.Auth;
using ExamManagement.Persistence;
using ExamManagement.Persistence.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Services
{
    public class AuthService : IAuthService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly JwtOptions _config;
        public AuthService(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher, IOptions<JwtOptions> config)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _config = config.Value;
        }

        public async Task<Result<LoginResponseModel>> Login(LoginRequestModel loginModelRequest)
        {
            var user = await _userRepository.GetByEmail(loginModelRequest.Email);
            if (user == null)
                return Result.Failure<LoginResponseModel>("User not found !");

            if (!_passwordHasher.Check(user.Password, loginModelRequest.Password))
                return Result.Failure<LoginResponseModel>("Invalid password !");

            return Result.Success<LoginResponseModel>(GenerateToken(user));
        }
        public async Task<Result<string>> Register(UpRegisterModel model)
        {
            /*
            var user = _mapper.Map<User>(model);

            await _authRepository.Register(user);
            await _authRepository.SaveChanges();

            return _mapper.Map<RegisterModel>(user);
            */
            var user = await _userRepository.GetByEmail(model.Email);
            if (user != null)
                return Result.Failure<string>("User already exists!");


            var newUser = new User(model.LastName,
                                    model.FirstName,
                                    model.Email,
                                    _passwordHasher.CreateHash(model.Password),
                                    0,
                                    model.FacultyId
                                    );

            await _userRepository.Add(newUser);
            await _userRepository.SaveChanges();


            

            return Result.Success<string>("User registered");
        }

        private LoginResponseModel GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var hours = int.Parse(_config.TokenExpirationInHours);


            var claims = (user.Role != 1) ? new List<Claim>()
                {
                    new Claim("userId", user.Id.ToString())
                } :
                new List<Claim>()
                {
                    new Claim("userId", user.Id.ToString()),
                    new Claim("isAdmin", "true")
                };

            var token = new JwtSecurityToken(_config.Issuer,
                _config.Audience,
                claims,
                expires: DateTime.Now.AddHours(hours),
                signingCredentials: credentials);

            return new LoginResponseModel(user.FirstName, user.LastName, user.Email, new JwtSecurityTokenHandler().WriteToken(token),user.Id);
        }
        /*
        public async Task<RegisterModel> Check(string email)
        {
            var user = await _authRepository.Check(email);

            return _mapper.Map<RegisterModel>(user);
        }
        */
    }
}

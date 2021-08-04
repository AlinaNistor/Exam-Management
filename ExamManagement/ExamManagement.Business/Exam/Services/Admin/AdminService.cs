using AutoMapper;
using CSharpFunctionalExtensions;
using ExamManagement.Business.Exam.Models.Admin;
using ExamManagement.Persistence.Auth;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Services.Admin
{
    public class AdminService : IAdminService
    {
       
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _accessor;

        public AdminService( IMapper mapper, IUserRepository userRepository, IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _mapper = mapper;

            _userRepository = userRepository;
        }

        public async Task<Result<UserModel>> Delete(Guid userId)
        {
            var authId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var auth = await _userRepository.GetById(authId);
            if (1 != auth.Role)
            {
                return Result.Failure<UserModel>("Unauthorised");
            }
            var user = await _userRepository.GetById(userId);
            if (user == null)
            {
                return Result.Failure<UserModel>("Unavailable");
            }

            _userRepository.Delete(user);
            await _userRepository.SaveChanges();

            return _mapper.Map<UserModel>(user);
        }

        public async Task<Result<UserModel>> Get(Guid userId)
        {
            var user = await _userRepository.GetById(userId);
            return user == null ? Result.Failure<UserModel>("User not found") : _mapper.Map<UserModel>(user);
        }

        public async Task<Result<IList<UserModel>>> GetUsers()
        {
            var userList = await _userRepository.GetUsers();
            var returnList = userList.OrderBy((a) => a.LastName)
                .Reverse()
                .ToList()
                .Select((user) => new UserModel(user.Id, user.LastName, user.FirstName, user.Email, user.Password, user.Role, user.FacultyId)).ToList();

            return Result.Success<IList<UserModel>>(returnList);
        }

        public async Task<Result<UserModel>> Update(Guid userId)
        {
            var authId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var auth = await _userRepository.GetById(userId);
            if (1 != auth.Role)
            {
                return Result.Failure<UserModel>("Unauthorised");
            }
            var user = await _userRepository.GetById(userId);
            if (user == null)
                return Result.Failure<UserModel>("User does not exist!");

            user.Role = 1;
            _userRepository.Update(user);
            await _userRepository.SaveChanges();

            return _mapper.Map<UserModel>(user);
        }
    }
}

using AutoMapper;
using Entities;
using ExamManagement.Business.Exam.Models;
using ExamManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Services
{
    public class RegisterService : IRegisterService
    {

        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;

        public RegisterService(IAuthRepository authRepository, IMapper mapper)
        {
            _authRepository = authRepository;
            _mapper = mapper;
        }
        public async Task<RegisterModel> Register(UpRegisterModel model)
        {
            var user = _mapper.Map<User>(model);

            await _authRepository.Register(user);
            await _authRepository.SaveChanges();

            return _mapper.Map<RegisterModel>(user);
        }
    }
}

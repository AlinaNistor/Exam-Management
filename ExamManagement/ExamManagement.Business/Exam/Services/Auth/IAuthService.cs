using ExamManagement.Business.Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpFunctionalExtensions;
using System.Threading.Tasks;
using ExamManagement.Business.Exam.Models.Auth;

namespace ExamManagement.Business.Exam.Services
{
   public interface IAuthService
    {
        Task<Result<string>> Register(UpRegisterModel model);

        Task<Result<LoginResponseModel>> Login(LoginRequestModel loginModelRequest);

        Task<Result<string>> ChangePassword(NewPasswordRequestModel model);

    }
}

using CSharpFunctionalExtensions;
using ExamManagement.Business.Exam.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Services.Admin
{
    public interface IAdminService
    {

        public Task<Result<UserModel>> Get(Guid userId);


        public Task<Result<UserModel>> Update(Guid userId);

        public Task<Result<UserModel>> Delete(Guid userId);

        public Task<Result<IList<UserModel>>> GetUsers();
    }
}

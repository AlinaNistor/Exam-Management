using ExamManagement.Business.Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Services
{
   public interface IRegisterService
    {
        Task<RegisterModel> Register(UpRegisterModel model);

        Task<RegisterModel> Check(string email);
    }
}

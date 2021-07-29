using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Services.Auth
{
    public interface IPasswordHasher
    {
        string CreateHash(string password);

        bool Check(string hash, string password);
    }
}

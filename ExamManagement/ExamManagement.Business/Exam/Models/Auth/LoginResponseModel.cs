using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Models.Auth
{
    public sealed class LoginResponseModel
    {
        public LoginResponseModel(string firstName,string lastName, string email, string token)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Token = token;
            
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Token { get; private set; }
    }
}

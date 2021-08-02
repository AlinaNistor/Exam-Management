using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Models.Auth
{
    public sealed class NewPasswordRequestModel
    {
        public string NewPassword { get; set; }
        public Guid Id { get; set; }
    }
}

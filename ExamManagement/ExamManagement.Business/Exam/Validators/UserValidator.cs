using ExamManagement.Business.Exam.Models.Admin;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Validators
{
    public class UserValidator:AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                ;

            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50)
                ;

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .MaximumLength(250);

            RuleFor(x => x.Role).NotEmpty().NotNull();


        }
    }
}

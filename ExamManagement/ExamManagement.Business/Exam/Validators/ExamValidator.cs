using ExamManagement.Business.Exam.Models.Exam;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Validators
{
    public class ExamValidator:AbstractValidator<ExamModel>
    {
       public ExamValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                ;

            RuleFor(x => x.YearOfStudy).NotNull().NotEmpty();
            RuleFor(x => x.Mandatory).NotNull().NotEmpty();
            RuleFor(x => x.HeadProfessor).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Details).MaximumLength(500);
            RuleFor(x => x.ExamType).NotEmpty();
            RuleFor(x => x.Location).MaximumLength(50);
            RuleFor(x => x.AcceptsCommentaries).NotNull().NotEmpty();

        }


    }
}

using ExamManagement.Business.Exam.Models.Comment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Validators
{
   public class CommentValidator:AbstractValidator<CommentModel>
    {
        public CommentValidator()
        {
            RuleFor(x => x.Text).NotEmpty().MaximumLength(255);
            RuleFor(x => x.Id).NotEmpty().NotNull();
            
        }


    }
}

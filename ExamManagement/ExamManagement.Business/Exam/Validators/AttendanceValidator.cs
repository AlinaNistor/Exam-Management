using ExamManagement.Business.Exam.Models.Attendance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Validators
{
    public class AttendanceValidator : AbstractValidator<AttendanceModel>
    {
        public AttendanceValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}

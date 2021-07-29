using CSharpFunctionalExtensions;
using ExamManagement.Business.Exam.Models.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Services.Exam
{
    public interface IExamService
    {
        public Task<Result<ExamModel>> Get(Guid examId);

        public Task<Result<ExamModel>> Add(ExamModel model);

        public Task<Result<ExamModel>> Update(Guid examId);

        public Task<Result<ExamModel>> Delete(Guid examId);
    }
}

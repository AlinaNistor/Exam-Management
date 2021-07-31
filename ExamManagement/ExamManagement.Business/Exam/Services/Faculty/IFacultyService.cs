using CSharpFunctionalExtensions;
using ExamManagement.Business.Exam.Models.Faculty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Services.Faculty
{
    public interface IFacultyService
    {
        public Task<Result<FacultyModel>> Get(Guid examId);

        public Task<Result<FacultyModel>> Add(FacultyModel model);

        public Task<Result<IList<FacultyModel>>> GetAll();
    }
}

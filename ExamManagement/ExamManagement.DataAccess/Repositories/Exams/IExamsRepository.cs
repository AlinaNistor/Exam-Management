using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Persistence.Exams
{
    public interface IExamsRepository : IExamRepository<Exam>
    {
        public Task<IList<Exam>> GetAll();

        public Task<Exam> GetByDate(string date);
    }
}

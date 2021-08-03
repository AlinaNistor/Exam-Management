using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Persistence.Exams
{
    public sealed class ExamsRepository : ExamRepository<Exam>, IExamsRepository
    {
        public ExamsRepository(ExamContext context) : base(context)
        {
        }

        public async Task<IList<Exam>> GetAll()
           => await _context
              .Exams
              .ToListAsync();


        public async Task<Exam> GetByDate(string date)
            => await _context
                .Exams
                .Where(exam => exam.Date == date)
                .FirstOrDefaultAsync();
    }
}

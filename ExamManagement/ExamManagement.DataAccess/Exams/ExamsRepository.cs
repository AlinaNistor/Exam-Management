using DataAccess;
using Entities;
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



    }
}

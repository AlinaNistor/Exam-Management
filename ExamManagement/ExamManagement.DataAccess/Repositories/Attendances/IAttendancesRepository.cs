using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Persistence.Repositories.Attendances
{
   public  interface IAttendancesRepository :IExamRepository<Attendance>
    {
        public Task<IList<Attendance>> GetAll();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamManagement.Persistence.Repositories.Attendances
{
    public sealed class AttendanceRepository : ExamRepository<Attendance>, IAttendancesRepository
    {
        public AttendanceRepository(ExamContext context):base(context)
        {
        }

        public async Task<IList<Attendance>> GetAll()
           => await _context
              .Attendances
              .ToListAsync();
    }
}

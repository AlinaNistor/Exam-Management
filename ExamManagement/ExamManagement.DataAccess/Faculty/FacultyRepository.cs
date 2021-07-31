using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Persistence.Faculty
{
    public class FacultyRepository: ExamRepository<Entities.Faculty>, IFacultyRepository
    {
        public FacultyRepository(ExamContext context):base(context)
        {
        }

        public async Task<IList<Entities.Faculty>> GetAll()
           => await _context
               .Faculties
               .ToListAsync();
    }
}

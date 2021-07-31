using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Persistence.Faculty
{
    public interface IFacultyRepository:IExamRepository<Entities.Faculty>
    {

        public Task<IList<Entities.Faculty>> GetAll();
    }
}

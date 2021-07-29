using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Persistence.Auth
{
    public interface IUserRepository : IExamRepository<User>
    {
        Task<IList<User>> GetUsers();

        Task<User> GetByEmail(string email);

    }
}

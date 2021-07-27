using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Persistence
{
    public interface IAuthRepository
    {
        Task Register(User user);

        Task SaveChanges();

        Task<User> Check(string email);
    }
}

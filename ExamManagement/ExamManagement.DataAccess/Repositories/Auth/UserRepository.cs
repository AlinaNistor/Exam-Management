using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Persistence.Auth
{
    public sealed class UserRepository : ExamRepository<User>, IUserRepository
    {
        public UserRepository(ExamContext context) : base(context)
        {
        }

        public async Task<IList<User>> GetUsers()
            => await _context
                .Users
                .ToListAsync();


        public async Task<User> GetByEmail(string email)
            => await _context
                .Users
                .Where(user => user.Email == email)
                .FirstOrDefaultAsync();

       
    }
}

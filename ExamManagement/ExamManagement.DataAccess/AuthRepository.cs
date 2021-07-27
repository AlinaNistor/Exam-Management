﻿using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Persistence
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ExamContext _context;

        public AuthRepository(ExamContext context)
        {
            _context = context;
        }

        public async Task Register(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<User> Check(string email)
        {
            return await _context.Users
                
                .FirstAsync(i => i.Email == email);
        }
    }
}
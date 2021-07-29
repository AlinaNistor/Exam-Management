using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Persistence
{
    public abstract class ExamRepository<T> : IExamRepository<T>
        where T: BaseEntity
    {
        protected readonly ExamContext _context;

        public ExamRepository(ExamContext context)
        {
            _context = context;
        }

        public async Task<T> GetById(Guid id)
            => await this._context.Set<T>().FindAsync(id);

        public async Task Add(T entity)
            => await this._context.Set<T>().AddAsync(entity);

        public void Update(T entity)
            => this._context.Set<T>().Update(entity);

        public void Delete(T entity)
            => this._context.Set<T>().Remove(entity);

        public Task SaveChanges()
            => this._context.SaveChangesAsync();
    }
}

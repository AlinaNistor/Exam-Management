using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Persistence
{
    public interface IExamRepository<T>
        where T : BaseEntity
    {
        Task<T> GetById(Guid id);

        Task Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task SaveChanges();
    }
}

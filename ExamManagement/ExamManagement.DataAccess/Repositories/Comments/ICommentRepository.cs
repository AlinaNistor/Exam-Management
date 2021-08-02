using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Persistence.Repositories.Comments
{
    public interface ICommentRepository : IExamRepository<Comment>
    {

        public Task<IList<Comment>> GetByExamId(Guid examId);
    }
}

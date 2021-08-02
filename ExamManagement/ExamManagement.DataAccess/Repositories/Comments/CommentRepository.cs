using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Persistence.Repositories.Comments
{
    public class CommentRepository: ExamRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ExamContext context):base(context)
        {
        }
        public async Task<IList<Comment>> GetByExamId(Guid examId)
           => await _context
              .Comments.Where(comment=>comment.ExamId==examId)
              .ToListAsync();
    }
}

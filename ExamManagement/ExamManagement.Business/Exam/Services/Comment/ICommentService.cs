using CSharpFunctionalExtensions;
using ExamManagement.Business.Exam.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Services.Comment
{
    public interface ICommentService
    {
        public Task<Result<CommentModel>> Get(Guid commentId);

        public Task<Result<CommentModel>> Add(CommentModel model);

       

        public Task<Result<CommentModel>> Delete(Guid commentId);
        public Task<Result<IList<CommentModel>>> GetByExamId(Guid examId);

    }
}

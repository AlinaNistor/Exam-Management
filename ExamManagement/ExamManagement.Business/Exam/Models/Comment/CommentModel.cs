using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Models.Comment
{
    public class CommentModel
    {
        public CommentModel(Guid id, Guid? parentId, Guid userId, Guid examId, string text, string dateAdded)
        {
            Id = id;
            ParentId = parentId;
            UserId = userId;
            ExamId = examId;
            Text = text;
            DateAdded = dateAdded;
        }
        public Guid Id { get; }
        public Guid? ParentId { get; set; }
        public Guid UserId { get; set; }
        public Guid ExamId { get; set; }
        public string Text { get; set; }

        public string DateAdded { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Comment:BaseEntity
    {
        public Comment():base()
        {

        }
        public Comment(string text, string dateAdded, Guid? parentId , Guid userId , Guid examId):base()
        {
            Text = text;
            DateAdded = dateAdded;
            ParentId = parentId;
            UserId = userId;
            ExamId = examId;
        }
        public Guid? ParentId { get; set; }
        public Guid UserId { get; set; }
        public Guid ExamId { get; set; }
        public string Text { get; set; }

        public string DateAdded { get; set; }

        public virtual Comment Parent { get; set; }
        public virtual User User { get; set; }
        public virtual Exam Exam { get; set; }
    }
}

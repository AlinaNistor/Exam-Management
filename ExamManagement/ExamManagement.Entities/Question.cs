using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Question:BaseEntity
    {
        public Question(string text, string dateAdded, Guid? examId, Guid userId) : base()
        {
            Text = text;
            DateAdded = dateAdded;
            ExamId = examId;
            UserId = userId;

            Answers = new List<Answer>();
        }

        public Guid? ExamId{ get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public string DateAdded { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }

    }
}

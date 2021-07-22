using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Answer:BaseEntity
    {
        public Answer(string text, string dateAdded, Guid? questionId , Guid userId):base()
        {
            Text = text;
            DateAdded = dateAdded;
            QuestionId = questionId;
            UserId = userId;
        }
        public Guid? QuestionId { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }

        public string DateAdded { get; set; }

        public virtual Question Question { get; set; }
        public virtual User User { get; set; }
    }
}

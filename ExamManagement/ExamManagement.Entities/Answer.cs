using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Answer:BaseEntity
    {
        public Guid? QuestionId { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }

        public string DateAdded { get; set; }

        public virtual Question Question { get; set; }
        public virtual User User { get; set; }
    }
}

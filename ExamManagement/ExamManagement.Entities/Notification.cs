using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Notification:BaseEntity
    {
        public Notification() : base()
        {

        }
        public Notification(Guid examId,string dateAdded,int notifyNoOfDaysPrior) : base()
        {
            ExamId = examId;
            DateAdded = dateAdded;
            NotifyNoOfDaysPrior = notifyNoOfDaysPrior;

        }


        public Guid ExamId { get; set; }
        public virtual Exam Exam { get; set; }
        public string DateAdded { get; set; }

        public int NotifyNoOfDaysPrior { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Models.Notification
{
    public class NotificationModel
    {
        public NotificationModel(Guid id, Guid examId, string dateAdded, int notifyNoOfDaysPrior)
        {
            Id = id;
            ExamId = examId;
            DateAdded = dateAdded;
            NotifyNoOfDaysPrior = notifyNoOfDaysPrior;
        }
        public Guid Id { get; }
        public Guid ExamId { get; set; }
     
        public string DateAdded { get; }

        public int NotifyNoOfDaysPrior { get; set; }
    }
}

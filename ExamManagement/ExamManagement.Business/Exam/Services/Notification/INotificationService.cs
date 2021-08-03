using CSharpFunctionalExtensions;
using ExamManagement.Business.Exam.Models.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Services.Notification
{
    public interface INotificationService
    {
        public Task<Result<NotificationModel>> Get(Guid notificationId);

        public Task<Result<NotificationModel>> Add(NotificationModel model);

       

        public Task<Result<NotificationModel>> Delete(Guid notificationId);
        public Task<Result<IList<NotificationModel>>> GetByExamId(Guid examId);
    }
}

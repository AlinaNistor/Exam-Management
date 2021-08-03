using AutoMapper;
using CSharpFunctionalExtensions;
using ExamManagement.Business.Exam.Models.Notification;
using ExamManagement.Persistence.Exams;
using ExamManagement.Persistence.Repositories.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Services.Notification
{
    public class NotificationService : INotificationService
    {

        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        private readonly IExamsRepository _examRepository;

        public NotificationService(INotificationRepository notificationRepository, IMapper mapper, IExamsRepository examRepository)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
            _examRepository = examRepository;
        }
        public async Task<Result<NotificationModel>> Add(NotificationModel model)
        {
            
            var notificationEntity = _mapper.Map<Entities.Notification>(model);
            notificationEntity.DateAdded = DateTime.Now.ToString();

            await _notificationRepository.Add(notificationEntity);
            await _notificationRepository.SaveChanges();

            return _mapper.Map<NotificationModel>(notificationEntity);
        }

        public async Task<Result<NotificationModel>> Delete(Guid notificationId)
        {
            var notification = await _notificationRepository.GetById(notificationId);
            if (notification == null)
            {
                return Result.Failure<NotificationModel>("Unavailable");
            }

            _notificationRepository.Delete(notification);
            await _notificationRepository.SaveChanges();

            return _mapper.Map<NotificationModel>(notification);
        }

        public async Task<Result<NotificationModel>> Get(Guid notificationId)
        {
            var notification = await _notificationRepository.GetById(notificationId);
            return notification == null ? Result.Failure<NotificationModel>("Notification not found") : _mapper.Map<NotificationModel>(notification);
        }

        public async Task<Result<IList<NotificationModel>>> GetByExamId(Guid examId)
        {
            var notificationList = await _notificationRepository.GetByExamId(examId);
            var returnList = notificationList.OrderBy((a) => a.DateAdded)
                .Reverse()
                .ToList()
                .Select((notification) => new NotificationModel(notification.Id, notification.ExamId, notification.DateAdded, notification.NotifyNoOfDaysPrior)).ToList();

            return Result.Success<IList<NotificationModel>>(returnList);
        }

       
    }
}

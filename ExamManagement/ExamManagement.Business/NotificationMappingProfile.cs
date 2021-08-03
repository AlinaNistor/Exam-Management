using AutoMapper;
using ExamManagement.Business.Exam.Models.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business
{
    public class NotificationMappingProfile:Profile
    {
        public NotificationMappingProfile()
        {
            CreateMap<Entities.Notification, NotificationModel>();
            CreateMap<NotificationModel, Entities.Notification>();
        }
    }
}

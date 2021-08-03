using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Persistence.Repositories.Notifications
{
    public class NotificationRepository : ExamRepository<Entities.Notification>, INotificationRepository
    {

        public NotificationRepository(ExamContext context):base(context)
        {

        }

        public async Task<IList<Notification>> GetByExamId(Guid examId)
         => await _context
              .Notification.Where(notification => notification.ExamId == examId)
              .ToListAsync();


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Persistence.Repositories.Notifications
{
    public interface INotificationRepository: IExamRepository<Entities.Notification>
    {
        Task<IList<Entities.Notification>> GetByExamId(Guid examId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Attendance : BaseEntity
    {

        public Attendance(string date, string dateAdded, Guid studentId, Guid? examId):base()
        {
            Date = date;
            DateAdded = dateAdded;
            ExamId = examId;
            StudentId = studentId;
        }
        public Guid? ExamId
        {
            get; set;
        }
        public Guid StudentId
        {
            get; set;
        }
        public string Date
        {
            get;set;
        }
        public string DateAdded { get; set; }

        public virtual User Student { get; set; }
        public virtual Exam Exam { get; set; }

    }
}

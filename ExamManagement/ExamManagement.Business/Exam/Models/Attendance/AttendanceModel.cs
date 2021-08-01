using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Models.Attendance
{
   public class AttendanceModel
    {

        public AttendanceModel(string date,  Guid studentId, Guid? examId, Guid id)
        {
            Date = date;
            
            ExamId = examId;
            StudentId = studentId;
            Id = id;
        }

        public Guid Id { get; }
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
            get; set;
        }
        
    }
}

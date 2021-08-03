using CSharpFunctionalExtensions;
using ExamManagement.Business.Exam.Models.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Services.Attendance
{
    public interface IAttendanceService
    {
        public Task<Result<AttendanceModel>> Get(Guid attendanceId);

        public Task<Result<AttendanceModel>> Add(AttendanceModel model);


        public Task<Result<AttendanceModel>> Delete(Guid attendanceId);

        public Task<Result<IList<AttendanceModel>>> GetAll();
    }
}

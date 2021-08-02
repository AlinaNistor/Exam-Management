using AutoMapper;
using CSharpFunctionalExtensions;
using ExamManagement.Business.Exam.Models.Attendance;
using ExamManagement.Persistence.Auth;
using ExamManagement.Persistence.Repositories.Attendances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Services.Attendance
{
    public class AttendanceService : IAttendanceService
    {

        private readonly IAttendancesRepository _attendancesRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public AttendanceService(IAttendancesRepository attendancesRepository, IMapper mapper, IUserRepository userRepository)
        {
            _attendancesRepository = attendancesRepository;
            _mapper = mapper;
            
            _userRepository = userRepository;
        }
        public async Task<Result<AttendanceModel>> Add(AttendanceModel model)
        {
            var attendanceEntity = _mapper.Map<Entities.Attendance>(model);
            attendanceEntity.DateAdded = DateTime.Now.ToString();

            await _attendancesRepository.Add(attendanceEntity);
            await _attendancesRepository.SaveChanges();

            return _mapper.Map<AttendanceModel>(attendanceEntity);
        }

        public async Task<Result<AttendanceModel>> Delete(Guid attendanceId)
        {
            var attendance = await _attendancesRepository.GetById(attendanceId);
            if (attendance == null)
            {
                return Result.Failure<AttendanceModel>("Unavailable");
            }

            _attendancesRepository.Delete(attendance);
            await _attendancesRepository.SaveChanges();

            return _mapper.Map<AttendanceModel>(attendance);
        }

        public async Task<Result<AttendanceModel>> Get(Guid attendanceId)
        {
            var attendance = await _attendancesRepository.GetById(attendanceId);
            return attendance == null ? Result.Failure<AttendanceModel>("Attendance not found") : _mapper.Map<AttendanceModel>(attendance);
        }

        public async Task<Result<IList<AttendanceModel>>> GetAll()
        {
            var attendanceList = await _attendancesRepository.GetAll();
            var returnList = attendanceList.OrderBy((a) => a.Student)
                .Reverse()
                .ToList()
                .Select((attendance) => new AttendanceModel(attendance.Date,  attendance.StudentId, attendance.ExamId, attendance.Id,attendance.DateAdded)).ToList();

            return Result.Success<IList<AttendanceModel>>(returnList);
        }

        public Task<Result<AttendanceModel>> Update(Guid attendanceId)
        {
            throw new NotImplementedException();
        }
    }
}

using AutoMapper;
using Entities;
using ExamManagement.Business.Exam.Models.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business
{
    public class AttendancesMappingProfile:Profile
    {

        public AttendancesMappingProfile()
        {
            CreateMap<Attendance, AttendanceModel>();
            CreateMap<AttendanceModel, Attendance>();
        }
    }
}

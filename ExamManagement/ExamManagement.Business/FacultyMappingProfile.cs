using AutoMapper;
using ExamManagement.Business.Exam.Models.Faculty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business
{
    public class FacultyMappingProfile:Profile
    {
        public FacultyMappingProfile()
        {
            CreateMap<Entities.Faculty, FacultyModel>();
            CreateMap<FacultyModel, Entities.Faculty>();
        }
    }
}

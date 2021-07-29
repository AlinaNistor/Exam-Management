using AutoMapper;
using ExamManagement.Business.Exam.Models.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business
{
    public class ExamsMappingProfile:Profile
    {
        public ExamsMappingProfile()
        {
            CreateMap<Entities.Exam, ExamModel>();
            CreateMap<ExamModel, Entities.Exam>();
        }
    }
}

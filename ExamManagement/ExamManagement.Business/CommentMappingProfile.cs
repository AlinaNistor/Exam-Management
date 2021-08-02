using AutoMapper;
using ExamManagement.Business.Exam.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business
{
    public class CommentMappingProfile:Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<Entities.Comment, CommentModel>();
            CreateMap<CommentModel, Entities.Comment>();
        }
    }
}

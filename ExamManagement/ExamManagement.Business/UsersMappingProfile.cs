using AutoMapper;
using Entities;
using ExamManagement.Business.Exam.Models;
using System;

namespace ExamManagement.Business
{
    public class UsersMappingProfile: Profile
    {
        public UsersMappingProfile()
        {
            CreateMap<User, RegisterModel>();
            CreateMap<UpRegisterModel, User>();
        }
    }
}

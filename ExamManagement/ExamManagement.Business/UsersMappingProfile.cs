using AutoMapper;
using Entities;
using ExamManagement.Business.Exam.Models;
using ExamManagement.Business.Exam.Models.Admin;
using System;

namespace ExamManagement.Business
{
    public class UsersMappingProfile: Profile
    {
        public UsersMappingProfile()
        {
            CreateMap<User, RegisterModel>();
            CreateMap<UpRegisterModel, User>();
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
        }
    }
}

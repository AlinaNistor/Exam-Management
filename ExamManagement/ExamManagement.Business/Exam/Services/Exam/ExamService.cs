using AutoMapper;
using CSharpFunctionalExtensions;
using Entities;
using ExamManagement.Business.Exam.Models.Exam;
using ExamManagement.Persistence.Auth;
using ExamManagement.Persistence.Exams;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Services.Exam
{
    public class ExamService : IExamService
    {
        private readonly IExamsRepository _examRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;
        private readonly IUserRepository _userRepository;

        public ExamService(IExamsRepository examRepository, IMapper mapper, IHttpContextAccessor accessor,IUserRepository userRepository)
        {
            _examRepository = examRepository;
            _mapper = mapper;
            _accessor = accessor;
            _userRepository = userRepository;
        }

       
        public async Task<Result<ExamModel>> Get(Guid examId)
        {
            var exam = await _examRepository.GetById(examId);
            return exam == null ? Result.Failure<ExamModel>("Unavailable exam") : _mapper.Map<ExamModel>(exam);
        }

        public async Task<Result<ExamModel>> Add(ExamModel model)
        {
            // Check authority
            
           var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var user = await _userRepository.GetById(userId);
            if (1 != user.Role)
            {
               return Result.Failure<ExamModel>("Unauthorised");
            }
           
           

            var examEntity = _mapper.Map<Entities.Exam>(model);
            examEntity.DateAdded = DateTime.Now.ToString();

            await _examRepository.Add(examEntity);
            await _examRepository.SaveChanges();

            return _mapper.Map<ExamModel>(examEntity);
        }

        public async Task<Result<ExamModel>> Update(Guid examId, ExamModel model)
        {
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var user = await _userRepository.GetById(userId);
            if (1 != user.Role)
            {
                return Result.Failure<ExamModel>("Unauthorised");
            }

            var exam = await _examRepository.GetById(examId);
            if (exam == null)
            {
                return Result.Failure<ExamModel>("Unavailable exam!");
            }
            if (model == null)
            {
                return Result.Failure<ExamModel>("Don't leave form empty !");
            }

            exam.AcceptsCommentaries = model.AcceptsCommentaries;
            exam.Date = model.Date;
            exam.Details = model.Details;
            exam.ExamType = model.ExamType;
            exam.HeadProfessor = model.HeadProfessor;
            exam.Mandatory = model.Mandatory;
            exam.YearOfStudy = model.YearOfStudy;
            exam.Name = model.Name;
            exam.Location = model.Location;
            
            _examRepository.Update(exam);
            await _userRepository.SaveChanges();

            return _mapper.Map<ExamModel>(exam);
        }

        public async Task<Result<ExamModel>> Delete(Guid examId)
        {
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var user = await _userRepository.GetById(userId);
            if (1 != user.Role)
            {
                return Result.Failure<ExamModel>("Unauthorised");
            }
            var exam = await _examRepository.GetById(examId);
            if (exam == null)
            {
                return Result.Failure<ExamModel>("Unavailable");
            }

            _examRepository.Delete(exam);
            await _examRepository.SaveChanges();

            return _mapper.Map<ExamModel>(exam);
        }

        public async Task<Result<IList<ExamModel>>> GetAll()
        {
            var examList = await _examRepository.GetAll();
            var returnList = examList.OrderBy((a) => a.Date)
                .ToList()
                .Select((exam) => new ExamModel(exam.Id, exam.FacultyId,exam.YearOfStudy, exam.Mandatory,exam.Name,exam.HeadProfessor,exam.Date,exam.ExamType,exam.Location, exam.Details, exam.DateAdded, exam.AcceptsCommentaries)).ToList();

            return Result.Success<IList<ExamModel>>(returnList);
        }

        public async Task<Result<ExamModel>> GetByDate(string date)
        {
            var exam = await _examRepository.GetByDate(date);
            return exam == null ? Result.Failure<ExamModel>("Unavailable exam") : _mapper.Map<ExamModel>(exam);
        }
    }
}

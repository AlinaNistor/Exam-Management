using AutoMapper;
using CSharpFunctionalExtensions;
using ExamManagement.Business.Exam.Models.Faculty;
using ExamManagement.Persistence.Auth;
using ExamManagement.Persistence.Faculty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Services.Faculty
{
    public class FacultyService:IFacultyService
    {

        private readonly IFacultyRepository _facultyRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public FacultyService(IFacultyRepository facultyRepository, IMapper mapper, IUserRepository userRepository)
        {
            _facultyRepository = facultyRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Result<IList<FacultyModel>>> GetAll()
        {
            var facultyList = await _facultyRepository.GetAll();
            var returnList = facultyList.OrderBy((a) => a.Name)
                .Reverse()
                .ToList()
                .Select((faculty) => new FacultyModel(faculty.Id, faculty.Name)).ToList();

            return Result.Success<IList<FacultyModel>>(returnList);
        }
        public async Task<Result<FacultyModel>> Get(Guid facultyId)
        {
            var faculty = await _facultyRepository.GetById(facultyId);
            return faculty == null ? Result.Failure<FacultyModel>("Unavailable faculty") : _mapper.Map<FacultyModel>(faculty);
        }


        public async Task<Result<FacultyModel>> Add(FacultyModel model)
        {
            

            var facultyEntity = _mapper.Map<Entities.Faculty>(model);
           

            await _facultyRepository.Add(facultyEntity);
            await _facultyRepository.SaveChanges();

            return _mapper.Map<FacultyModel>(facultyEntity);
        }
    }
}

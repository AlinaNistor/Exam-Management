using CSharpFunctionalExtensions;
using ExamManagement.Business.Exam.Models.Faculty;
using ExamManagement.Business.Exam.Services.Faculty;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {

        private readonly IFacultyService _facultyService;

        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }
        // GET: api/<FacultyController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var (_, _, result, _) = await _facultyService.GetAll();
            return Ok(result);
        }

        // GET api/<FacultyController>/5
        [HttpGet("{facultyId}")]
        public async Task<IActionResult> Get([FromRoute] Guid facultyId)
        {
            var (_, isFailure, result, error) = await _facultyService.Get(facultyId);
            if (isFailure)
            {
                return BadRequest(error);
            }
            return Ok(result);
        }

        // POST api/<FacultyController>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] FacultyModel faculty)
        {
            var (_, isFailure, result, error) = await _facultyService.Add(faculty);
            if (isFailure)
            {
                return BadRequest(error);
            }
            return Created(result.Name.ToString(), result);
        }

    }
}

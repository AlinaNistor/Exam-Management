using ExamManagement.Business.Exam.Models.Exam;
using ExamManagement.Business.Exam.Services.Exam;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {

        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }
        // GET: api/<ExamController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var (_, _, result, _) = await _examService.GetAll();
            return Ok(result);
        }

        // GET api/<ExamController>/5
        [HttpGet("{examId}")]
        public async Task<IActionResult> Get([FromRoute] Guid examId)
        {
            var (_, isFailure, result, error) = await _examService.Get(examId);
            if (isFailure)
            {
                return BadRequest(error);
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("Date")]
        public async Task<IActionResult> GetByDate( string examDate )
        {
            var (_, isFailure, result, error) = await _examService.GetByDate(examDate);
            if (isFailure)
            {
                return BadRequest(error);
            }
            return Ok(result);
        }
        // POST api/<ExamController>
        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody] ExamModel exam)
        {
            var (_, isFailure, result, error) = await _examService.Add(exam);
            if (isFailure)
            {
                return BadRequest(error);
            }
            return Created(result.Name.ToString(), result);
        }

        // DELETE api/<ExamController>/5
        [HttpDelete("{examId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid examId)
        {
            var (_, isFailure, result, error) = await _examService.Delete(examId);
            if (isFailure)
            {
                return BadRequest(error);
            }
            return Ok(result);
        }
    }
}

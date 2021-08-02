using CSharpFunctionalExtensions;
using ExamManagement.Business.Exam.Models.Attendance;
using ExamManagement.Business.Exam.Services.Attendance;
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
    public class AttendanceController : ControllerBase
    {

        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }
        // GET: api/<AttendanceController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var (_, _, result, _) = await _attendanceService.GetAll();
            return Ok(result);
        }

        // GET api/<AttendanceController>/5
        [HttpGet("{attendanceId}")]
        public async Task<IActionResult> Get([FromRoute] Guid attendanceId)
        {
            var (_, isFailure, result, error) = await _attendanceService.Get(attendanceId);
            if (isFailure)
            {
                return BadRequest(error);
            }
            return Ok(result);
        }

        // POST api/<AttendanceController>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AttendanceModel attendance)
        {
            var (_, isFailure, result, error) = await _attendanceService.Add(attendance);
            if (isFailure)
            {
                return BadRequest(error);
            }
            return Created(result.ExamId.ToString(), result);
        }

        

        // DELETE api/<AttendanceController>/5
        [HttpDelete("{attendanceId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid attendanceId)
        {
            var (_, isFailure, result, error) = await _attendanceService.Delete(attendanceId);
            if (isFailure)
            {
                return BadRequest(error);
            }
            return Ok(result);
        }
    }
}

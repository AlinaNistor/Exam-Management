using CSharpFunctionalExtensions;
using ExamManagement.Business.Exam.Models.Notification;
using ExamManagement.Business.Exam.Services.Notification;
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
    public class NotificationController : ControllerBase
    {

        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        // GET: api/<NotificationController>
        [HttpGet("{examId}")]
        public async Task<IActionResult> GetByExamId([FromRoute] Guid examId)
        {
            var (_, _, result, _) = await _notificationService.GetByExamId(examId);
            return Ok(result);
        }

        // GET api/<NotificationController>/5
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> Get([FromRoute] Guid Id)
        {
            var (_, isFailure, result, error) = await _notificationService.Get(Id);
            if (isFailure)
            {
                return BadRequest(error);
            }
            return Ok(result);
        }

        // POST api/<NotificationController>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] NotificationModel notification)
        {
            var (_, isFailure, result, error) = await _notificationService.Add(notification);
            if (isFailure)
            {
                return BadRequest(error);
            }
            return Created(result.Id.ToString(), result);
        }


        // DELETE api/<NotificationController>/5
        [HttpDelete("{notificationId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid notificationId)
        {
            var (_, isFailure, result, error) = await _notificationService.Delete(notificationId);
            if (isFailure)
            {
                return BadRequest(error);
            }
            return Ok(result);
        }
    }
}

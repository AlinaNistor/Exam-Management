using CSharpFunctionalExtensions;
using ExamManagement.Business.Exam.Services.Admin;
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

    
    public class AdminController : ControllerBase
    {

        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        // GET: api/<AdminController>
        [HttpGet("users")]
        
        public async Task<IActionResult> GetUsers()
        {
            var (_, isFailure, result, error) = await _adminService.GetUsers();
            if (isFailure)
            {
                return BadRequest(error);
            }

            return Ok(result);
        }

        // GET api/<AdminController>/5
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get([FromRoute] Guid userId)
        {
            var (_, isFailure, result, error) = await _adminService.Get(userId);
            if (isFailure)
            {
                return BadRequest(error);
            }
            return Ok(result);
        }

       

        // PUT api/<AdminController>/5
        [HttpPut("{userId}")]
        public async Task<IActionResult> Update([FromRoute] Guid userId)
        {
            var (_, isFailure, result, error) = await _adminService.Update(userId);
            if (isFailure)
            {
                return BadRequest(error);
            }
            return Ok();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid userId)
        {
            var (_, isFailure, result, error) = await _adminService.Delete(userId);
            if (isFailure)
            {
                return BadRequest(error);
            }
            return Ok(result);
        }
    }
}

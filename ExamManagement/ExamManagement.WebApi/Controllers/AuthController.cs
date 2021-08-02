using CSharpFunctionalExtensions;
using ExamManagement.Business.Exam.Models;
using ExamManagement.Business.Exam.Models.Auth;
using ExamManagement.Business.Exam.Services;
using Microsoft.AspNetCore.Http;
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
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        

        // POST api/<AuthController>
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequestModel modelRequest)
        {
            var (_, isFailure, value, error) = await _authService.Login(modelRequest);
            if (isFailure)
                return BadRequest(error);
            return Ok(value);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UpRegisterModel model)
        {

            var (_, isFailure, value, error) = await _authService.Register(model);
            if (isFailure)
                return BadRequest(error);
            return Created(value, null);
        }

        [HttpPut("change-password")]
       
        public async Task<IActionResult> ChangePassword([FromBody] NewPasswordRequestModel modelRequest)
        {
            var (_, isFailure, value, error) = await _authService.ChangePassword(modelRequest);
            if (isFailure)
                return BadRequest(error);
            return Ok(new { value });
        }

    }
}

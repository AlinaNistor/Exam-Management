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
        // GET: api/<AuthController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
            /*
            var userExists = _registerService.Check(model.Email);
            if(userExists!=null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User already exists!" });
            }
            var result = await _registerService.Register(model);

            return Created(result.Id.ToString(), null);
            */

            var (_, isFailure, value, error) = await _authService.Register(model);
            if (isFailure)
                return BadRequest(error);
            return Created(value, null);
        }

        // PUT api/<AuthController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using CSharpFunctionalExtensions;
using ExamManagement.Business.Exam.Models.Comment;
using ExamManagement.Business.Exam.Services.Comment;
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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentSErvice;

        public CommentController(ICommentService commentService)
        {
            _commentSErvice = commentService;
        }
        // GET: api/<CommentController>
        [HttpGet("{examId}")]
        public async Task<IActionResult> GetByExamId([FromRoute] Guid examId)
        {
            var (_, _, result, _) = await _commentSErvice.GetByExamId(examId);
            return Ok(result);
        }

        /*
        [HttpGet("{commentId}")]
        public async Task<IActionResult> Get([FromRoute] Guid commentId)
        {
            var (_, isFailure, result, error) = await _commentSErvice.Get(commentId);
            if (isFailure)
            {
                return BadRequest(error);
            }
            return Ok(result);
        }
        */
        // POST api/<CommentController>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CommentModel comment)
        {
            var (_, isFailure, result, error) = await _commentSErvice.Add(comment);
            if (isFailure)
            {
                return BadRequest(error);
            }
            return Created(result.Id.ToString(), result);
        }



        // DELETE api/<CommentController>/5
        [HttpDelete("{commentId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid commentId)
        {
            var (_, isFailure, result, error) = await _commentSErvice.Delete(commentId);
            if (isFailure)
            {
                return BadRequest(error);
            }
            return Ok(result);
        }
    }
}

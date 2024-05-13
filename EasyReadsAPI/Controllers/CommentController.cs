using EasyReadsBLL.DTOs;
using EasyReadsBLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyReadsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentService _commentService;
        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateComment(CommentDTO commentDTO)
        {
            if(ModelState.IsValid)
            {
                _commentService.CreateComment(commentDTO);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult GetComment(int id)
        {
            var data = _commentService.GetComment(id);
            if(data != null)
            {
                return Ok(data);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("allcomments/{articleId}")]
        public IActionResult GetAllComments(int articleId)
        {
            var data = _commentService.GetAllComments(articleId);
            return Ok(data);
        }


        [HttpPut]
        [Route("update/{id}")]
        public IActionResult UpdateComment(CommentDTO commentDTO)
        {
            if (ModelState.IsValid)
            {
                _commentService.UpdateComment(commentDTO);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteComment(int id)
        {
            _commentService.DeleteComment(id);
            return Ok();
        }


        // Replies

        [HttpPost]
        [Route("reply/create")]
        public IActionResult CreateReply(ReplyDTO replyDTO)
        {
            if (ModelState.IsValid)
            {
                _commentService.CreateReply(replyDTO);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("get/{commentId}/reply/{replyId}")]
        public IActionResult GetReply(int commentId, int replyId)
        {
            var data = _commentService.GetReply(replyId);
            if (data != null)
            {
                return Ok(data);
            }
            return BadRequest();
        }


        [HttpGet]
        [Route("get/{commentId}/reply")]
        public IActionResult GetAllReplies(int commentId)
        {
            var data = _commentService.GetAllReplies(commentId);
            return Ok(data);
        }


        [HttpPut]
        [Route("reply/{id}")]
        public IActionResult UpdateReply(ReplyDTO replyDTO)
        {
            if (ModelState.IsValid)
            {
                _commentService.UpdateReply(replyDTO);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("reply/delete/{id}")]
        public IActionResult DeleteReply(int id)
        {
            _commentService.DeleteReply(id);
            return Ok();
        }

    }
}

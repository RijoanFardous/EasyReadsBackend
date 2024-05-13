using EasyReadsBLL.DTOs;
using EasyReadsBLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyReadsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly LikeService _likeService;
        public LikeController(LikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateLike(LikeDTO data)
        {
            if (ModelState.IsValid)
            {
                _likeService.CreateLike(data);
                return Ok();
            }
            return BadRequest();
        }


        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteFollower(LikeDTO data)
        {
            if (ModelState.IsValid)
            {
                _likeService.DeleteLike(data);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetAllLikes/{articleId}")]
        public IActionResult GetAllFollowers(int articleId)
        {
            var data = _likeService.GetAllLikes(articleId);
            return Ok(data);
        }
    }
}

using EasyReadsBLL.DTOs;
using EasyReadsBLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyReadsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowerController : ControllerBase
    {
        private readonly FollowerService _followerService;
        public FollowerController(FollowerService followerService)
        {
            _followerService = followerService;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateFollower(FollowerDTO data)
        {
            if(ModelState.IsValid)
            {
                _followerService.CreateFollower(data);
                return Ok();
            }
            return BadRequest();
        }


        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteFollower(FollowerDTO data)
        {
            if (ModelState.IsValid)
            {
                _followerService.DeleteFollower(data);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetAllFollowers/{username}")]
        public IActionResult GetAllFollowers(string username)
        {
            var data = _followerService.GetAllFollowers(username);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetAllFollowings/{username}")]
        public IActionResult GetAllFollowings(string username)
        {
            var data = _followerService.GetAllFollowings(username);
            return Ok(data);
        }
    }
}

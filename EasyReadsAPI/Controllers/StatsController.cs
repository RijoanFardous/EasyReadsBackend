using EasyReadsBLL.Models;
using EasyReadsBLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyReadsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly StatsService _statsService;
        public StatsController(StatsService statsService)
        {
            _statsService = statsService;
        }

        [HttpGet]
        [Route("user/{username}")]
        public IActionResult GetStatsByUser(AuthorStats stats)
        {
            try
            {
                var data = _statsService.GetAuthorStats(stats);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("top/articles")]
        public IActionResult GetTopArticles()
        {
            try
            {
                var data = _statsService.GetTopArticles();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("topic/{topicId}")]
        public IActionResult GetStatsByUser(TopicStats stats)
        {
            try
            {
                var data = _statsService.GetTopicStats(stats);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("basic")]
        public IActionResult GetBasicStats()
        {
            try
            {
                var data = _statsService.GetBasicStats();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

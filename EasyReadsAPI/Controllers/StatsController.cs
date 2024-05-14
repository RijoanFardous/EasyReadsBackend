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
        [Route("{username}")]
        public IActionResult GetStatsByUser(string username, DateTime? startdate, DateTime? enddate)
        {
            try
            {
                var data = _statsService.GetAuthorStats(username, startdate, enddate);
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
    }
}

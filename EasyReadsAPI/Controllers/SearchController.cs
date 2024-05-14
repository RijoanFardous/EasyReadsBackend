using EasyReadsBLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyReadsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly SearchService _searchService;
        public SearchController(SearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        [Route("/{keyword}")]
        public IActionResult Search(string keyword)
        {
            if(keyword == null)
            {
                return BadRequest();
            }

            if (keyword.StartsWith("@"))
            {
                keyword = keyword.Substring(1);
                var users = _searchService.SearchUsers(keyword);
                return Ok(users);
            }
            else
            {
                var articles = _searchService.SearchArticles(keyword);
                return Ok(articles);
            }
        }
    }
}

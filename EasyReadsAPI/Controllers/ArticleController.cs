using EasyReadsAPI.Auth;
using EasyReadsBLL.DTOs;
using EasyReadsBLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyReadsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleService _articleService;
        public ArticleController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        [TypeFilter(typeof(AuthorAttribute))]
        [HttpPost]
        [Route("create")]
        public IActionResult CreateArticle(ArticleDTO article)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _articleService.CreateArticle(article);
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Occurred: {ex.Message}");
            }
        }
    }
}

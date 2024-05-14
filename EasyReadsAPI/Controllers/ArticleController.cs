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


        [TypeFilter(typeof(AuthorAttribute))]
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteArticle(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _articleService.RemoveArticle(id);
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("get/{articleId}")]
        public IActionResult GetArticle(int articleId)
        {
            try
            {
                var tokenkey = HttpContext.Request.Headers["Authorization"];
                var data = _articleService.GetArticle(articleId, tokenkey);
                if(data != null)
                {
                    if (String.IsNullOrEmpty(data.Title))
                    {
                        return Unauthorized();
                    }
                    return Ok(data);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Occurred: {ex.Message}");
            }
        }


        [HttpGet]
        [Route("get/all/public")]
        public IActionResult GetAllPublicArticles()
        {
            try
            {
                List<ArticleDTO> data = _articleService.GetAllPublicArticles();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("get/all/{username}/public")]
        public IActionResult GetAllPublicArticlesByUser(string username)
        {
            try
            {
                List<ArticleDTO> data = _articleService.GetAllPublicArticlesByUser(username);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Occurred: {ex.Message}");
            }
        }

        [TypeFilter(typeof(LoggedAttribute))]
        [HttpGet]
        [Route("get/all/{username}/followers")]
        public IActionResult GetAllFollowerArticlesByUser(string username)
        {
            try
            {
                List<ArticleDTO> data = _articleService.GetAllFollowerArticlesByUser(username);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Occurred: {ex.Message}");
            }
        }

        [TypeFilter(typeof(AuthorAttribute))]
        [HttpGet]
        [Route("get/all/{username}/private")]
        public IActionResult GetAllArticlesByUser(string username)
        {
            try
            {
                List<ArticleDTO> data = _articleService.GetAllArticlesByUser(username);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("get/all/topic/{topicId}")]
        public IActionResult GetArticlesByTopicId(int topicId)
        {
            try
            {
                List<ArticleDTO> data = _articleService.GetAllArticlesByTopicId(topicId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Occurred: {ex.Message}");
            }
        }


        [TypeFilter(typeof(AuthorAttribute))]
        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Update(ArticleDTO article)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _articleService.UpdateArticle(article);
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Occurred: {ex.Message}");
            }
        }

        [TypeFilter(typeof(AuthorAttribute))]
        [HttpGet]
        [Route("version/get/{id}")]
        public IActionResult GetArticleVersion(int id)
        {
            try
            {
                var data = _articleService.GetArticleVersion(id);
                if(data == null)
                {
                    return BadRequest();
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Occurred: {ex.Message}");
            }
        }

        [TypeFilter(typeof(AuthorAttribute))]
        [HttpGet]
        [Route("version/get/all/{articleId}")]
        public IActionResult GetAllArticleVersion(int articleId)
        {
            try
            {
                var data = _articleService.GetAllArticleVersion(articleId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Occurred: {ex.Message}");
            }
        }

        [TypeFilter(typeof(AuthorAttribute))]
        [HttpGet]
        [Route("version/restore/{id}")]
        public IActionResult RestoreVersion(int id)
        {
            try
            {
                _articleService.RestoreVersion(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Occurred: {ex.Message}");
            }
        }
    }
}

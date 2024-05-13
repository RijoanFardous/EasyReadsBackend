using EasyReadsBLL.DTOs;
using EasyReadsBLL.Services;
using EasyReadsDAL.EF.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyReadsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {
        private readonly BookmarkService _bookmarkService;
        public BookmarkController(BookmarkService bookmarkService)
        {
            _bookmarkService = bookmarkService;
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult GetBookmark(int id)
        {
            var bookmark = _bookmarkService.GetBookmark(id);
            if (bookmark != null)
            {
                return Ok(bookmark);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("get/{username}")]
        public IActionResult GetAllBookmarks(string username)
        {
            var bookmarks = _bookmarkService.GetAllBookmarks(username);
            return Ok(bookmarks);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Deletebookmark(BookmarkDTO bookmark)
        {
            if (ModelState.IsValid)
            {
                _bookmarkService.Delete(bookmark);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(BookmarkDTO bookmark)
        {
            if (ModelState.IsValid)
            {
                _bookmarkService.Create(bookmark);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}

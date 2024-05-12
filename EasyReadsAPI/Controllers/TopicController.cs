using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyReadsBLL.DTOs;
using EasyReadsBLL.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyReadsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : Controller
    {

        private readonly TopicService _topicService;

        public TopicController(TopicService topicService)
        {
            _topicService = topicService;
        }


        [HttpPost]
        [Route("addTopic")]
        public IActionResult AddTopic(TopicDTO topic)
        {

            if (ModelState.IsValid)
            {
                _topicService.Create(topic);
                return Ok();
            }


            return BadRequest(ModelState);


        }

        [HttpGet]
        [Route("GetAllTopic")]
        public IActionResult GetAllTopic()
        {
          var allData = _topicService.GetAllTopic();
            return Ok(allData);

        }

        [HttpGet]
        [Route("GetTopic/{id}")]
        public IActionResult getTopicById(int id)
        {
            var topic = _topicService.getTopic(id);

            if(topic != null)
            {
                return Ok(topic);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("UpdateTopic/{id}")]
        public IActionResult UpdateTopic (TopicDTO singletopic)
        {
             _topicService.UpdateTopic(singletopic);
            return Ok();
        }









    }
}


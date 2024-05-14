using EasyReadsBLL.DTOs;
using EasyReadsBLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyReadsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationService _applicationService;
        public ApplicationController(ApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateApplication(ApplicationDTO data)
        {
            if(ModelState.IsValid)
            {
                _applicationService.CreateApplication(data);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("reject/{id}")]
        public IActionResult RejectApplication(int id)
        {
            _applicationService.Reject(id);
            return Ok();
        }

        [HttpPut]
        [Route("approve/{id}")]
        public IActionResult ApproveApplication(int id, string username)
        {
            _applicationService.Approve(id, username);
            return Ok();
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult GetApplication(int id)
        {
            var data = _applicationService.GetApplication(id);
            if(data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("get/{username}")]
        public IActionResult GetApplicationByUser(string username)
        {
            var data = _applicationService.GetApplicationByUser(username);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetApplications()
        {
            var data = _applicationService.GetAll();
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("getall/approved")]
        public IActionResult GetApprovedApplications()
        {
            var data = _applicationService.GetAllApproved();
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("getall/rejected")]
        public IActionResult GetRejectedApplications()
        {
            var data = _applicationService.GetAllRejected();
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("getall/pending")]
        public IActionResult GetPendingApplications()
        {
            var data = _applicationService.GetAllPendings();
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

    }
}

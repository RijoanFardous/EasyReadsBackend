using EasyReadsAPI.Auth;
using EasyReadsBLL.DTOs;
using EasyReadsBLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyReadsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportService _reportService;
        public ReportController(ReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateReport(ReportDTO data)
        {
            if (ModelState.IsValid)
            {
                _reportService.CreateReport(data);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [TypeFilter(typeof(AdminAttribute))]
        [HttpPut]
        [Route("reject/{id}")]
        public IActionResult RejectReport(int id)
        {
            _reportService.Reject(id);
            return Ok();
        }

        [TypeFilter(typeof(AdminAttribute))]
        [HttpPut]
        [Route("approve/{id}")]
        public IActionResult ApproveReport(int id, int articleId)
        {
            _reportService.Approve(id, articleId);
            return Ok();
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult GetReport(int id)
        {
            var data = _reportService.GetReport(id);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("get/user/{username}")]
        public IActionResult GetReportByUser(string username)
        {
            var data = _reportService.GetReportByUser(username);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetReports()
        {
            var data = _reportService.GetAll();
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("getall/approved")]
        public IActionResult GetApprovedReports()
        {
            var data = _reportService.GetAllApproved();
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("getall/rejected")]
        public IActionResult GetRejectedReports()
        {
            var data = _reportService.GetAllRejected();
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("getall/pending")]
        public IActionResult GetPendingReports()
        {
            var data = _reportService.GetAllPendings();
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }
    }
}

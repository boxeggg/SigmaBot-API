using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SigmaBotAPI.Models;
using SigmaBotAPI.Services;

namespace SigmaBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;
        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }
        [HttpGet]
        public IActionResult GetStatus()
        {
            var status = _statusService.GetStatus();
            return Ok(status);
        }
        [HttpPatch]
        public IActionResult UpdateStatus([FromBody] JsonPatchDocument<StatusModel> model)
        {
            var status = _statusService.GetStatus();
            model.ApplyTo(status);
            if (_statusService.UpdateStatus(status))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}

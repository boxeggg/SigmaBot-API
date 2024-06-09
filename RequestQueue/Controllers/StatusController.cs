using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestQueue.Models;
using RequestQueue.Services;

namespace RequestQueue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;
        public StatusController(IStatusService statusService) { 
            _statusService = statusService;
        }
        [HttpGet]
        public IActionResult GetStatus() {
        var status = _statusService.GetStatus();
        return Ok(status);
        }
        [HttpPatch]
        public IActionResult UpdateStatus(StatusModel model) {
            if(_statusService.UpdateStatus(model))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}

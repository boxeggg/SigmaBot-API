using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestQueue.Models;
using RequestQueue.Services;

namespace RequestQueue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;
        public RequestController(IRequestService requestService) { 
            _requestService = requestService;
        }
        [HttpGet("all")]
        public IActionResult GetAllRequests() {
            var requests = _requestService.GetAllRequest();
             return Ok(requests);
        }
        [HttpGet("last")]
        public IActionResult GetLastRequest()
        {
            var request = _requestService.GetLastRequest();
            if (request != null)
            {
                return Ok(request);
            }
            else
            {
                return BadRequest("There is no songs in the queue");
            }
        }
        [HttpDelete("last")]
        public IActionResult Delete()
        {
            if (_requestService.RemoveRequest()) {
                return Ok();
            }
            else {
                return BadRequest("Failed removing request");
            }    
            
        }
        [HttpGet("count")]
        public IActionResult GetRequestCount()
        {
            int request = _requestService.RequestsCount();
            return Ok(request);
        }
        [HttpPost("new")]
        public IActionResult AddRequest(RequestModel requestModel)
        {
            if (_requestService.AddRequest(requestModel))
            {
                return Ok();
            }
            else { return BadRequest("Failed adding new request"); };
        }





    }
}

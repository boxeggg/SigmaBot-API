using Microsoft.AspNetCore.Mvc;
using SigmaBotAPI.Models;
using SigmaBotAPI.Services;

namespace SigmaBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        /// <summary>
        /// Retrieves all requests.
        /// </summary>
        /// <returns>A list of all requests.</returns>
        [HttpGet]
        public IActionResult GetAllRequests()
        {
            var requests = _requestService.GetAllRequest();
            return Ok(requests);
        }

        /// <summary>
        /// Retrieves the last request in the queue.
        /// </summary>
        /// <returns>The last request if it exists, otherwise a Bad Request response.</returns>
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

        /// <summary>
        /// Deletes the last request in the queue.
        /// </summary>
        /// <returns>Ok if successful, otherwise a Bad Request response.</returns>
        [HttpDelete("last")]
        public IActionResult Delete()
        {
            if (_requestService.RemoveRequest())
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Failed removing request");
            }
        }

        /// <summary>
        /// Clears all requests in the queue.
        /// </summary>
        /// <returns>Ok if successful, otherwise a Bad Request response.</returns>
        [HttpDelete("clear")]
        public IActionResult Clear()
        {
            if (_requestService.ClearQueue())
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Failed removing request");
            }
        }

        /// <summary>
        /// Retrieves the count of requests in the queue.
        /// </summary>
        /// <returns>The number of requests.</returns>
        [HttpGet("count")]
        public IActionResult GetRequestCount()
        {
            int request = _requestService.RequestsCount();
            return Ok(request);
        }

        /// <summary>
        /// Adds a new request to the queue.
        /// </summary>
        /// <param name="requestModel">The request model to add.</param>
        /// <returns>Ok if successful, otherwise a Bad Request response.</returns>
        [HttpPost("new")]
        public IActionResult AddRequest(RequestModel requestModel)
        {
            requestModel.DateTime = DateTime.Now;
            if (_requestService.AddRequest(requestModel))
            {
                return Ok();
            }
            else { return BadRequest("Failed adding new request"); };
        }
        [HttpPost("playlist")]
        public IActionResult AddPlaylist(ICollection<RequestModel> playlist)
        {
            ICollection<RequestModel> newPlaylist = new List<RequestModel>();

            foreach (var item in playlist)
            {

                var newItem = new RequestModel
                {
                    Name = item.Name,
                    Url = item.Url,
                    User = item.User,
                    Thumbnail_Url = item.Thumbnail_Url,
                    DateTime = DateTime.Now,

                };

                newPlaylist.Add(newItem);
            }

            if (_requestService.AddPlaylist(newPlaylist))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Failed to add new request");
            }
        }

    }
}


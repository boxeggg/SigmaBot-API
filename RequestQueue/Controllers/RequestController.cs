using Microsoft.AspNetCore.Mvc;
using SigmaBotAPI.Data.Entities;
using SigmaBotAPI.Services;

namespace SigmaBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly ISongRepository _requestService;
        private readonly IStatusRepository _statusRepository;

        public RequestController(ISongRepository requestService, IStatusRepository statusRepository)
        {
            _requestService = requestService;
            _statusRepository = statusRepository;

        }

        /// <summary>
        /// Retrieves all requests.
        /// </summary>
        /// <returns>A list of all requests.</returns>
        [HttpGet]
        public IActionResult GetAllRequests(string guildId)
        {
            try
            {
                var requests = _requestService.GetAllRequests(guildId);
                return Ok(requests);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves the last request in the queue.
        /// </summary>
        /// <returns>The last request if it exists, otherwise a Bad Request response.</returns>
        [HttpGet("last")]
        public IActionResult GetLastRequest(string guildId)
        {
            var request = _requestService.GetLastRequest(guildId);
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
        public IActionResult Delete(string guildId)
        {
            if (_requestService.RemoveLastRequest(guildId))
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
        public IActionResult Clear(string guildId)
        {
            if (_requestService.ClearQueue(guildId))
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
        public IActionResult GetRequestCount(string guildId)
        {
            try
            {
                int request = _requestService.RequestsCount(guildId);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adds a new request to the queue.
        /// </summary>
        /// <param name="requestModel">The request model to add.</param>
        /// <returns>Ok if successful, otherwise a Bad Request response.</returns>
        [HttpPost("new")]
        public IActionResult AddRequest(SongEntity requestModel)
        {

            var newSong = new SongEntity()
            {
                Id = requestModel.Id,
                Name = requestModel.Name,
                Url = requestModel.Url,
                User = requestModel.User,
                Thumbnail_Url = requestModel.Thumbnail_Url,
                DateTime = DateTime.Now,
                GuildId = requestModel.GuildId,
                Status = _statusRepository.GetStatus(requestModel.GuildId)



            };
            if (_requestService.AddRequest(newSong))
            {
                return Ok();
            }
            else { return BadRequest("Failed adding new request"); };
        }
        [HttpPost("playlist")]
        public IActionResult AddPlaylist(ICollection<SongEntity> playlist)
        {
            ICollection<SongEntity> newPlaylist = new List<SongEntity>();

            foreach (var item in playlist)
            {

                var newItem = new SongEntity
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
                return BadRequest("Failed to add new playlist");
            }
        }

    }
}


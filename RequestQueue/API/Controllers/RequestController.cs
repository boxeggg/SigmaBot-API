using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SigmaBotAPI.Application.Models;
using SigmaBotAPI.Domain.Data.Entities;
using SigmaBotAPI.Domain.Repositories;

namespace SigmaBotAPI.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly ISongRepository _requestService;
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;


        public RequestController(ISongRepository requestService, IStatusRepository statusRepository, IMapper mapper)
        {
            _requestService = requestService;
            _statusRepository = statusRepository;
            _mapper = mapper;

        }


        [HttpGet]
        public IActionResult GetAllRequests(string guildId)
        {
            try
            {
                var status =  _statusRepository.GetStatus(guildId);
                if(status == null)  return NotFound();
                var requests = _mapper.Map<List<SongModel>>(_requestService.GetAllRequests(guildId));
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("last")]
        public IActionResult Delete(string guildId)
        {
            try
            {
                var status = _statusRepository.GetStatus(guildId);
                if (status == null) return NotFound();
                if (_requestService.RemoveLastRequest(guildId)) return Ok();
                else return NotFound();
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("clear")]
        public IActionResult Clear(string guildId)
        {
            try
            {
                var status = _statusRepository.GetStatus(guildId);
                if (status == null) return NotFound();
                _requestService.ClearQueue(guildId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("count")]
        public IActionResult GetRequestCount(string guildId)
        {
            try
            {
                var status = _statusRepository.GetStatus(guildId);
                if (status == null) return NotFound();
                int request = _requestService.RequestsCount(guildId);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("new")]
        public IActionResult AddRequest([FromBody] SongModel requestModel)
        {
            var status = _statusRepository.GetStatus(requestModel.GuildId);
            if (status == null) return NotFound($"Cannot find GuildId: {requestModel.GuildId}");

            var newSong = new SongEntity()
            {
                Id = requestModel.Id,
                Name = requestModel.Name,
                Url = requestModel.Url,
                User = requestModel.User,
                Thumbnail_Url = requestModel.Thumbnail_Url,
                DateTime = DateTime.Now,
                GuildId = requestModel.GuildId,
                Status = status
            };
            if (_requestService.AddRequest(newSong))
            {
                return Ok();
            }
            else { return BadRequest("Failed adding new request"); };
        }
        [HttpPost("playlist")]
        public IActionResult AddPlaylist([FromBody] ICollection<SongModel> playlist)
        {
            ICollection<SongEntity> newPlaylist = new List<SongEntity>();

            foreach (var item in playlist)
            {
                var status = _statusRepository.GetStatus(item.GuildId);
                if (status == null) return NotFound($"Cannot find GuildId: {item.GuildId}");
                var newItem = new SongEntity
                {
                    Id = item.Id,
                    Name = item.Name,
                    Url = item.Url,
                    User = item.User,
                    Thumbnail_Url = item.Thumbnail_Url,
                    DateTime = DateTime.Now,
                    GuildId = item.GuildId,
                    Status = _statusRepository.GetStatus(item.GuildId)

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


using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SigmaBotAPI.Application.Models;
using SigmaBotAPI.Domain.Data.Entities;
using SigmaBotAPI.Domain.Repositories;

namespace SigmaBotAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusService;
        private IMapper _mapper;

        public StatusController(IStatusRepository statusService, IMapper mapper)
        {

            _statusService = statusService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetStatus(string guildId)
        {
            try
            {
                var status = _mapper.Map<StatusModel>(_statusService.GetStatus(guildId));
                if (status == null)
                {
                    return NotFound();
                }


                return Ok(status);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("all")]
        public IActionResult GetStatuses()
        {
            try
            {
                return Ok(_mapper.Map<List<StatusModel>>(_statusService.GetAllStatuses()));

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        public IActionResult CreateStatus(string guildId, string guildName)
        {
            try
            {
                if (_statusService.CreateStatus(guildId, guildName))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPatch]
        public IActionResult UpdateStatus([FromBody] JsonPatchDocument<StatusEntity> model, string guildId)
        {
            var status = _statusService.GetStatus(guildId);
            if (status == null)
            {
                return NotFound();
            }

            model.ApplyTo(status);
            if (_statusService.UpdateStatus(status))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult ResetStatus(string guildId)
        {
            if (_statusService.ResetStatus(guildId))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult DeleteStatus(string guildId)
        {
            if (_statusService.DeleteStatus(guildId))
            {
                return Ok();
            }
            return NotFound();

        }
    }
}

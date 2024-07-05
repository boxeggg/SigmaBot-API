﻿using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SigmaBotAPI.Data.Entities;
using SigmaBotAPI.Services;

namespace SigmaBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusService;
        public StatusController(IStatusRepository statusService)
        {
            _statusService = statusService;
        }
        [HttpGet]
        public IActionResult GetStatus(string guildId)
        {
            try
            {
                var status = _statusService.GetStatus(guildId);
                return Ok(status);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        public IActionResult CreateStatus(string guildId)
        {
            try
            {
               if( _statusService.CreateStatus(guildId)) return Ok();
                return BadRequest();

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
    }
}

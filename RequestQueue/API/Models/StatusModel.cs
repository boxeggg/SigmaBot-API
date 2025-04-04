﻿using SigmaBotAPI.Domain.Data.Entities;

namespace SigmaBotAPI.Application.Models
{
    public class StatusModel
    {
        public string GuildId { get; set; }
        public string GuildName { get; set; }
        public LoopModes LoopMode { get; set; }
        public bool OnVoiceChannel { get; set; }
        public double Volume { get; set; }
        public bool SkipQueued { get; set; }

    }
}

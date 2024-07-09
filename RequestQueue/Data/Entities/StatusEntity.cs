using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SigmaBotAPI.Data.Entities
{
    public class StatusEntity
    {
        [Key]
        public string GuildId { get; set; }
        public string GuildName { get; set; }
        public LoopModes LoopMode { get; set; }
        public bool OnVoiceChannel { get; set; }
        public double Volume { get; set; }
        public bool SkipQueued { get; set; }
        public ICollection<SongEntity> SongsQueue { get; set; }


    }
    public enum LoopModes
    {
        None = 0,
        Song = 1,
        Queue = 2,
    }
}

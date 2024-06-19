namespace RequestQueue.Models
{
    public class StatusModel
    {
        public string GuildId { get; set; }
        public LoopModes LoopMode { get; set; }
        public bool OnVoiceChannel { get; set; } 
        public double Volume { get; set; } 
        public bool SkipQueued { get; set; }  
        public StatusModel() {
            GuildId = "";
            LoopMode = LoopModes.None;
            OnVoiceChannel = false;
            Volume = 50;
            SkipQueued = false;
        }
        
    }
    public enum LoopModes
    {
        None = 0,
        Song = 1,
        Queue = 2,
    }
}

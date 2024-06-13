namespace RequestQueue.Models
{
    public class StatusModel
    {
        public bool OnVoiceChannel { get; set; } 
        public double Volume { get; set; } 
        public bool skipQueued { get; set; }  
        public StatusModel() { 
            OnVoiceChannel = false;
            Volume = 50;
            skipQueued = false;
        }
        
    }
}

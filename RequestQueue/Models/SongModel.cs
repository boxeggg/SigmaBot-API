namespace SigmaBotAPI.Models
{
    public class SongModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string User { get; set; }
        public string Thumbnail_Url { get; set; }
        public DateTime DateTime { get; set; }
        public string GuildId { get; set; }
    }
}

namespace SigmaBotAPI.Application.Models
{
    public class SongModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string User { get; set; }
        public string Thumbnail_Url { get; set; }
        public DateTime DateTime { get; set; }
        public string GuildId { get; set; }
    }
}

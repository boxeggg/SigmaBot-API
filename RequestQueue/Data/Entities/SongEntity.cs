using System.ComponentModel.DataAnnotations;

namespace SigmaBotAPI.Data.Entities
{
    public class SongEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string User { get; set; }
        public string Thumbnail_Url { get; set; }
        public DateTime DateTime { get; set; }
        public string GuildId { get; set; }
        public StatusEntity Status { get; set; }


    }
}

using Microsoft.EntityFrameworkCore;
using SigmaBotAPI.Data.Entities;

namespace SigmaBotAPI.Data
{
    public class AppDbContext : DbContext
    {
        public  DbSet<SongEntity> SongEntity { get; set; }
        public  DbSet<StatusEntity> StatusEntity { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<StatusEntity>().HasMany(n => n.SongsQueue).WithOne(n => n.Status).HasForeignKey(n => n.GuildId);
        }
    }
}

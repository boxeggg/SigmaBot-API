using Microsoft.EntityFrameworkCore;
namespace RequestQueue.Models

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
        {
        }

        
        public DbSet<RequestModel> RequestModel { get; set; }
    }
}


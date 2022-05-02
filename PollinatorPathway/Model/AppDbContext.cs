using Microsoft.EntityFrameworkCore;

namespace PollinatorPathway.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

       
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UploadedImage> UploadedImages { get; set; }

    }
}

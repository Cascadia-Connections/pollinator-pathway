using Microsoft.EntityFrameworkCore;
using PollinatorPathway.Model;

namespace PollinatorPathway.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }


        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UploadedImage> UploadedImages { get; set; }

    }
}

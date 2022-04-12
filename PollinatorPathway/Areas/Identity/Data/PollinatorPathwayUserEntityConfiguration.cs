using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PollinatorPathway.Areas.Identity.Data;

namespace PollinatorPathway.Data
{
    internal class PollinatorPathwayUserEntityConfiguration : IEntityTypeConfiguration<PollinatorPathwayUser>
    {
        public void Configure(EntityTypeBuilder<PollinatorPathwayUser> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(255);
            builder.Property(u => u.LastName).HasMaxLength(255);
        }
    }
}
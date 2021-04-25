using FindExactSolution.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindExactSolution.Infrastructure.Persistence.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(t => t.FirstName)
                   .IsRequired()
                   .HasMaxLength(56);

            builder.Property(t => t.LastName)
                   .IsRequired()
                   .HasMaxLength(56);
        }
    }
}

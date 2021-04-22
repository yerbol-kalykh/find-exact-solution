using FindExactSolution.Domain.Common;
using FindExactSolution.Domain.Entities;
using FindExactSolution.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindExactSolution.Infrastructure.Persistence.Configurations
{
    public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.Property(t => t.Status)
                 .IsRequired();

            builder.HasOne(s => (ApplicationUser)s.User)
                    .WithMany(g => g.Registrations);
        }
    }
}

using FindExactSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindExactSolution.Infrastructure.Persistence.Configurations
{
    public class ChallengeConfiguration : IEntityTypeConfiguration<Challenge>
    {
        public void Configure(EntityTypeBuilder<Challenge> builder)
        {
            builder.Property(t => t.Title)
                   .IsRequired()
                   .HasMaxLength(512);

            builder.Property(t => t.Body)
                   .IsRequired();

            builder.Property(t => t.Order)
                   .IsRequired();
        }
    }
}
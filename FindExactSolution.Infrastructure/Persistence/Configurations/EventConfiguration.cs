using FindExactSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindExactSolution.Infrastructure.Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");

            builder.Property(x => x.IsActive).IsRequired();

            builder.Property(t => t.Description)
                   .IsRequired()
                   .HasMaxLength(512);

            builder.Property(t => t.Title)
                   .IsRequired()
                   .HasMaxLength(256);
        }
    }
}

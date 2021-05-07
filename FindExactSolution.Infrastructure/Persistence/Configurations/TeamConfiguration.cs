using FindExactSolution.Domain.Entities;
using FindExactSolution.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace FindExactSolution.Infrastructure.Persistence.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.HasMany(t => (ICollection<ApplicationUser>)t.Users)
                   .WithMany(u => u.Teams)
                   .UsingEntity(j => j.ToTable("TeamUsers"));

            builder.HasOne(e => e.Event)
                   .WithMany(t => t.Teams)
                   .HasForeignKey(e => e.EventId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
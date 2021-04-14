using FindExactSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindExactSolution.Infrastructure.Persistence.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(t => t.Title)
                   .IsRequired()
                   .HasMaxLength(512);

            builder.Property(t => t.Description)
                   .IsRequired();
        }
    }
}

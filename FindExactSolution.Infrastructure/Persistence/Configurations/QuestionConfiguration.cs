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

            builder.Property(t => t.Body)
                   .IsRequired();

            builder.Property(t => t.Order)
                   .IsRequired();

            builder.Property(t => t.Input)
                   .IsRequired();

            builder.Property(t => t.Answer)
                   .IsRequired();
        }
    }
}
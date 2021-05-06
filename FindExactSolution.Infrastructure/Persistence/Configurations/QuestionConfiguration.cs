using FindExactSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindExactSolution.Infrastructure.Persistence.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(x => x.Point).IsRequired();

            builder.Property(x => x.Description).IsRequired();

            builder.Property(x => x.Input).IsRequired();

            builder.Property(x => x.Answer).IsRequired();
        }
    }
}

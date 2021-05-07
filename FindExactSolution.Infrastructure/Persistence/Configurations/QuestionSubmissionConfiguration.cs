using FindExactSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindExactSolution.Infrastructure.Persistence.Configurations
{
    public class QuestionSubmissionConfiguration : IEntityTypeConfiguration<QuestionSubmission>
    {
        public void Configure(EntityTypeBuilder<QuestionSubmission> builder)
        {
            builder.Property(x => x.IsCorrect).IsRequired();

            builder.Property(x => x.LastSubmittedDateTime).IsRequired();
        }
    }
}

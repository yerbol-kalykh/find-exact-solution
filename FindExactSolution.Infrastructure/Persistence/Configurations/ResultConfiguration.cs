using FindExactSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindExactSolution.Infrastructure.Persistence.Configurations
{
    public class ResultConfiguration : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.HasKey(a => new { a.EventId, a.TeamId });

            builder.Property(x => x.TotalPoints).IsRequired();
            builder.Property(x => x.TotalChallenges).IsRequired();
            builder.Property(x => x.TotalQuestions).IsRequired();
            builder.Property(x => x.SolvedChallenges).IsRequired();
            builder.Property(x => x.SolvedQuestions).IsRequired();
        }
    }
}

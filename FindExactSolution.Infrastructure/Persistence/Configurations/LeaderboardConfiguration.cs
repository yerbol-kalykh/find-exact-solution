using FindExactSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindExactSolution.Infrastructure.Persistence.Configurations
{
    public class LeaderboardConfiguration : IEntityTypeConfiguration<Leaderboard>
    {
        public void Configure(EntityTypeBuilder<Leaderboard> builder)
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

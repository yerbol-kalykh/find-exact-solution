using FindExactSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Team> Teams { get; set; }

        DbSet<Event> Events { get; set; }

        DbSet<Challenge> Challenges { get; set; }

        DbSet<Registration> Registrations { get; set; }

        DbSet<Question> Questions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

using FindExactSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindExactSolution.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Team> Teams { get; set; }
    }
}

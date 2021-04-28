using FindExactSolution.Application.Common.Interfaces;
using FindExactSolution.Common.Extensions;
using FindExactSolution.Domain.Entities;
using FindExactSolution.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Area.Admin.Teams.Commands.GenerateTeams
{
    public class GenerateTeamsCommand : IRequest
    {
        public Guid EventId { get; set; }

        public int TeamSize { get; set; } = 5;
    }

    public class GenerateTeamsCommandHandler : IRequestHandler<GenerateTeamsCommand>
    {
        private readonly IApplicationDbContext _context;

        public GenerateTeamsCommandHandler(IApplicationDbContext context, IIdentityService identityService)
        {
            _context = context;
        }

        public async Task<Unit> Handle(GenerateTeamsCommand request, CancellationToken cancellationToken)
        {
            await DeletePreviousCreatedTeamsAsync(request.EventId);

            var registrations = await _context.Registrations.Include(r => r.User).Where(r => r.EventId == request.EventId
                                          && r.Status == RegistrationStatus.Registered).Select(r => r.User).ToListAsync(cancellationToken);

            registrations.Shuffle();

            var groups = registrations.SplitList(request.TeamSize);

            var counter = 1;

            foreach (var group in groups)
            {
                var team = new Team() { EventId = request.EventId, Users = group, Name = $"Team {counter++}" };

                _context.Teams.Add(team);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        public async Task DeletePreviousCreatedTeamsAsync(Guid eventId)
        {
            var teams = await _context.Teams.Where(t => t.EventId == eventId).ToListAsync();

            _context.Teams.RemoveRange(teams);

        }
    }
}
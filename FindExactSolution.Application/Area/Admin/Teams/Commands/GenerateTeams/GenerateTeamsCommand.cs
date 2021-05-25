using AutoMapper;
using FindExactSolution.Application.Area.Admin.Teams.Models;
using FindExactSolution.Application.Common.Interfaces;
using FindExactSolution.Common.Extensions;
using FindExactSolution.Domain.Entities;
using FindExactSolution.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Area.Admin.Teams.Commands.GenerateTeams
{
    public class GenerateTeamsCommand : IRequest<IEnumerable<AdminTeamDto>>
    {
        public Guid EventId { get; set; }

        public int TeamSize { get; set; } = 5;
    }

    public class GenerateTeamsCommandHandler : IRequestHandler<GenerateTeamsCommand, IEnumerable<AdminTeamDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GenerateTeamsCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AdminTeamDto>> Handle(GenerateTeamsCommand request, CancellationToken cancellationToken)
        {
            await DeletePreviousCreatedTeamsAsync(request.EventId, cancellationToken);

            var registrations = await _context.Registrations.Include(r => r.User).Where(r => r.EventId == request.EventId
                                          && r.Status == RegistrationStatus.Registered).Select(r => r.User).ToListAsync(cancellationToken);

            registrations.Shuffle();

            var groups = registrations.SplitList(request.TeamSize);

            var counter = 1;

            var teams = new List<Team>();

            foreach (var group in groups)
            {
                var team = new Team() { EventId = request.EventId, Users = group, Name = $"Team {counter++}" };

                teams.Add(team);
            }

            await _context.Teams.AddRangeAsync(teams, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<IEnumerable<AdminTeamDto>>(teams);
        }

        public async Task DeletePreviousCreatedTeamsAsync(Guid eventId, CancellationToken cancellationToken)
        {
            var teams = await _context.Teams.Where(t => t.EventId == eventId).ToListAsync(cancellationToken);

            _context.Teams.RemoveRange(teams);

        }
    }
}
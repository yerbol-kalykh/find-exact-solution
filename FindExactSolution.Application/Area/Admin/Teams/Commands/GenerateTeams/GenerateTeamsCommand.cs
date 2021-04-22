using FindExactSolution.Application.Common.Interfaces;
using FindExactSolution.Common.Extensions;
using FindExactSolution.Domain.Entities;
using MediatR;
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
        private readonly IIdentityService _identityService;

        public GenerateTeamsCommandHandler(IApplicationDbContext context, IIdentityService identityService)
        {
            _context = context;
            _identityService = identityService;
        }

        public async Task<Unit> Handle(GenerateTeamsCommand request, CancellationToken cancellationToken)
        {
            var users = (await _identityService.GetAllUsersAsync()).ToList();

            users.Shuffle();

            var groups = users.SplitList(request.TeamSize);

            var counter = 1;

            foreach(var group in groups)
            {
                var team = new Team() { EventId = request.EventId, Users = group, Name=$"Team {counter++}"};

                _context.Teams.Add(team);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
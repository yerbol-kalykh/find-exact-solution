using AutoMapper;
using FindExactSolution.Application.Common.Exceptions;
using FindExactSolution.Application.Common.Interfaces;
using FindExactSolution.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Teams.Commands.EditTeam
{
    public class EditTeamCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }

    public class EditTeamCommandHandler : IRequestHandler<EditTeamCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;

        public EditTeamCommandHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<Unit> Handle(EditTeamCommand request, CancellationToken cancellationToken)
        {
            var team = await _context.Teams.Include(t => t.Users)
                                          .FirstOrDefaultAsync(t => t.Users.Any(u => u.Id == _userService.UserId), cancellationToken);

            if(team == null)
            {
                throw new NotFoundException(nameof(Team), request.Id);
            }

            _mapper.Map(request, team);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

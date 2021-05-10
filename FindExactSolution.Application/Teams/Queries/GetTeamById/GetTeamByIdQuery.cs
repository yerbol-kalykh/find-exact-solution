using AutoMapper;
using FindExactSolution.Application.Common.Exceptions;
using FindExactSolution.Application.Common.Interfaces;
using FindExactSolution.Application.Teams.Models;
using FindExactSolution.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Teams.Queries.GetTeamById
{
    public class GetTeamByIdQuery : IRequest<TeamDto>
    {
        public Guid Id { get; set; }
    }

    public class GetTeamByIdQueryHandler : IRequestHandler<GetTeamByIdQuery, TeamDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;

        public GetTeamByIdQueryHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<TeamDto> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
        {
            var team = await _context.Teams.Include(t => t.Users)
                                           .FirstOrDefaultAsync(t => t.Users.Any(u => u.Id == _userService.UserId), cancellationToken);

            if (team == null)
            {
                throw new NotFoundException(nameof(Team), request.Id);
            }

            return _mapper.Map<TeamDto>(team);
        }
    }
}

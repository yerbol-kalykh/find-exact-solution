using AutoMapper;
using FindExactSolution.Application.Common.Interfaces;
using FindExactSolution.Application.Common.Security;
using FindExactSolution.Application.Events.Models;
using FindExactSolution.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Events.Queries.GetUserEventById
{
    [Authorize]
    public class GetUserEventByIdQuery : IRequest<EventDetailsDto>
    {
        public Guid Id { get; set; }
    }

    public class GetUserEventByIdQueryHandler : IRequestHandler<GetUserEventByIdQuery, EventDetailsDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;

        public GetUserEventByIdQueryHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<EventDetailsDto> Handle(GetUserEventByIdQuery request, CancellationToken cancellationToken)
        {
            var eventEntity = await _context.Events.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            var response = new EventDetailsDto();

            _mapper.Map(eventEntity, response);

            response.IsCurrentUserRegistered = await _context.Registrations.AnyAsync(r => r.UserId == _userService.UserId
                                            && r.Status != RegistrationStatus.Cancelled,  cancellationToken);

            var team = await _context.Teams.Include(t => t.Users)
                             .FirstOrDefaultAsync(t => t.Users.Any(u => u.Id == _userService.UserId), cancellationToken: cancellationToken);

            _mapper.Map(team, response.Team);

            return response;
        }
    }
}

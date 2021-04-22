using AutoMapper;
using FindExactSolution.Application.Common.Interfaces;
using FindExactSolution.Application.Common.Security;
using FindExactSolution.Application.Events.Models;
using FindExactSolution.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Events.Queries.GetEventById
{
    [Authorize]
    public class GetEventByIdQuery : IRequest<EventDetailsDto>
    {
        public Guid Id { get; set; }
    }

    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, EventDetailsDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;

        public GetEventByIdQueryHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<EventDetailsDto> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var eventEntity = await _context.Events.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            var response = new EventDetailsDto();

            _mapper.Map(eventEntity, response);

            response.IsCurrentUserRegistered = await _context.Registrations.AnyAsync(r => r.UserId == _userService.UserId
                                            && r.Status != RegistrationStatus.Cancelled,  cancellationToken);

            return response;
        }
    }
}

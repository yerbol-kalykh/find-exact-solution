using AutoMapper;
using FindExactSolution.Application.Area.Admin.Events.Models;
using FindExactSolution.Application.Common.Exceptions;
using FindExactSolution.Application.Common.Interfaces;
using FindExactSolution.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Area.Admin.Events.Queries.GetEventDetails
{
    public class GetEventDetailsQuery : IRequest<EventDetailDto>
    {
        public Guid Id { get; set; }
    }

    public class GetEventDetailsQueryHandler : IRequestHandler<GetEventDetailsQuery, EventDetailDto>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        public GetEventDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;

            _mapper = mapper;
        }

        public async Task<EventDetailDto> Handle(GetEventDetailsQuery request, CancellationToken cancellationToken)
        {
            var eventDetail = await _context.Events.Include(e=>e.Challenges).Include(e=>e.Registrations)
                                                   .ThenInclude(r=>r.User).Include(e=>e.Teams)
                                                   .ThenInclude(t=>t.Users).FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (eventDetail == null)
            {
                throw new NotFoundException(nameof(Event), request.Id);
            }
            return _mapper.Map<EventDetailDto>(eventDetail);
        }
    }


}

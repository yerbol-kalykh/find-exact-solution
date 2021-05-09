using AutoMapper;
using AutoMapper.QueryableExtensions;
using FindExactSolution.Application.Area.Admin.Events.Models;
using FindExactSolution.Application.Common.Interfaces;
using FindExactSolution.Application.Common.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Area.Admin.Events.Queries.GetAllEvents
{
    [Authorize]
    public class GetAllEventsQuery : IRequest<IEnumerable<AdminEventDto>>
    {
        
    }

    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, IEnumerable<AdminEventDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllEventsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AdminEventDto>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Events
                                  .AsNoTracking()
                                  .ProjectTo<AdminEventDto>(_mapper.ConfigurationProvider)
                                  .ToListAsync(cancellationToken);
        }
    }
}

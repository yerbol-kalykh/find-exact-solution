using AutoMapper;
using AutoMapper.QueryableExtensions;
using FindExactSolution.Application.Common.Interfaces;
using FindExactSolution.Application.Common.Security;
using FindExactSolution.Application.Events.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Events.Queries.GetEvents
{
    [Authorize]
    public class GetEventsQuery : IRequest<IEnumerable<EventDto>>
    {

    }

    public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, IEnumerable<EventDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetEventsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventDto>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            return  await _context.Events
                                  .AsNoTracking()
                                  .Where(e=>!e.DeletedDate.HasValue)
                                  .ProjectTo<EventDto>(_mapper.ConfigurationProvider)
                                  .ToListAsync(cancellationToken);
        }
    }
}

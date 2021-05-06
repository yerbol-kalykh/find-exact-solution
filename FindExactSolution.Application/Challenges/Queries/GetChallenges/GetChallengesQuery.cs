using AutoMapper;
using AutoMapper.QueryableExtensions;
using FindExactSolution.Application.Challenges.Models;
using FindExactSolution.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Challenges.Queries.GetChallenges
{
    public class GetChallengesQuery : IRequest<IEnumerable<ChallengeDto>>
    {
        public Guid EventId { get; set; }
    }

    public class GetChallengesQueryHandler : IRequestHandler<GetChallengesQuery, IEnumerable<ChallengeDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetChallengesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ChallengeDto>> Handle(GetChallengesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Challenges.AsNoTracking()
                                           .Include(q => q.Questions)
                                           .Where(q => q.EventId == request.EventId)
                                           .OrderBy(q => q.Order)
                                           .ProjectTo<ChallengeDto>(_mapper.ConfigurationProvider)
                                           .ToListAsync(cancellationToken);
        }
    }
}
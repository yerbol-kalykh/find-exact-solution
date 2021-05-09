using AutoMapper;
using AutoMapper.QueryableExtensions;
using FindExactSolution.Application.Common.Interfaces;
using FindExactSolution.Application.Leaderboards.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Leaderboards.Queries.GetLeaderboard
{
    public class GetLeaderboardQuery : IRequest<LeaderboardDto>
    {
        public Guid EventId { get; set; }
    }

    public class GetLeaderboardQueryHandler : IRequestHandler<GetLeaderboardQuery, LeaderboardDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetLeaderboardQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LeaderboardDto> Handle(GetLeaderboardQuery request, CancellationToken cancellationToken)
        {
            var results = await _context.Results.AsNoTracking()
                                       .Where(l => l.EventId == request.EventId)
                                       .ProjectTo<ResultLeaderboardDto>(_mapper.ConfigurationProvider)
                                       .ToListAsync(cancellationToken);

            var leaderboard = new LeaderboardDto
            {
                Results = results
            };

            return leaderboard;
        }
    }
}

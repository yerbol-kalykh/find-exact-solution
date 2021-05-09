using AutoMapper;
using FindExactSolution.Application.Common.Interfaces;
using FindExactSolution.Application.Leaderboard.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Leaderboard.Queries.GetLeaderboard
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
            //var currentEvent = await _context.Events.AsNoTracking()
            //                                        .Include(e => e.Teams)
            //                                        .ThenInclude(t => t.QuestionSubmissions)
            //                                        .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            //var leaderboard = new EventLeaderboardDto
            //{
            //    Teams = _mapper.Map<IEnumerable<EventLeaderboardTeamDto>>(currentEvent.Teams).OrderByDescending(t => t.TotalEarned)
            //};

            //return new EventLeaderboardDto();

            return new LeaderboardDto();
        }
    }
}

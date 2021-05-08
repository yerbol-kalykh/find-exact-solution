using AutoMapper;
using FindExactSolution.Application.Challenges.Models;
using FindExactSolution.Application.Common.Exceptions;
using FindExactSolution.Application.Common.Interfaces;
using FindExactSolution.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Challenges.Queries.GetChallenges
{
    public class GetChallengesQuery : IRequest<ChallengesResult>
    {
        public Guid EventId { get; set; }
    }

    public class GetChallengesQueryHandler : IRequestHandler<GetChallengesQuery, ChallengesResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetChallengesQueryHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<ChallengesResult> Handle(GetChallengesQuery request, CancellationToken cancellationToken)
        {
            var team = await _context.Teams.Include(t => t.Users)
                                           .FirstOrDefaultAsync(t => t.EventId == request.EventId
                                                                && t.Users.Any(u => u.Id == _currentUserService.UserId), cancellationToken);

            if (team == null)
            {
                throw new NotFoundException(nameof(Event), request.EventId);
            }

            var eventWithChallenges = await _context.Events
                                                    .AsNoTracking()
                                                    .Include(e => e.Challenges)
                                                    .ThenInclude(q => q.Questions)
                                                    .ThenInclude(q => q.QuestionSubmissions.Where(qs => qs.TeamId == team.Id))
                                                    .FirstOrDefaultAsync(q => q.Id == request.EventId, cancellationToken);

            if (eventWithChallenges == null)
            {
                throw new NotFoundException(nameof(Event), request.EventId);
            }

            var challengesResult = new ChallengesResult()
            {
                Event = _mapper.Map<EventChallengeDto>(eventWithChallenges),
                Challenges = _mapper.Map<IEnumerable<ChallengeDto>>(eventWithChallenges.Challenges.OrderBy(c => c.Order))
            };

            return challengesResult;
        }
    }
}
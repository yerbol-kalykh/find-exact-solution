using AutoMapper;
using FindExactSolution.Application.Area.Admin.Results.Models;
using FindExactSolution.Application.Common.Interfaces;
using FindExactSolution.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Area.Admin.Results.Commands
{
    public class GenerateLeaderboardCommand : IRequest<IEnumerable<AdminResultDto>>
    {
        public Guid EventId { get; set; }
    }

    public class GenerateLeaderboardCommandHandler : IRequestHandler<GenerateLeaderboardCommand, IEnumerable<AdminResultDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GenerateLeaderboardCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AdminResultDto>> Handle(GenerateLeaderboardCommand request, CancellationToken cancellationToken)
        {
            await DeletePreviousCreatedLeaderboardAsync(request.EventId);

            var teams = await _context.Teams.AsNoTracking()
                                            .Where(r => r.EventId == request.EventId)
                                            .ToListAsync(cancellationToken);

            var challenges = await _context.Challenges.AsNoTracking()
                                                      .Include(c=>c.Questions)
                                                      .Where(c => c.EventId == request.EventId)
                                                      .ToListAsync(cancellationToken);

            var totalQuestions = challenges.Sum(c => c.Questions.Count);

            var resultsDto = teams.Select(team => AdminResultDto.Create(request.EventId, team.Id, team.Name, challenges.Count, totalQuestions));

            await _context.Results.AddRangeAsync(_mapper.Map<IEnumerable<Result>>(resultsDto), cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return resultsDto;
        }

        public async Task DeletePreviousCreatedLeaderboardAsync(Guid eventId)
        {
            var results = await _context.Results.Where(t => t.EventId == eventId).ToListAsync();

            _context.Results.RemoveRange(results);

        }
    }
}

using AutoMapper;
using FindExactSolution.Application.Area.Admin.Challenges.Models;
using FindExactSolution.Application.Common.Exceptions;
using FindExactSolution.Application.Common.Interfaces;
using FindExactSolution.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Area.Admin.Challenges.Queries.GetChallengeDetails
{
    public class GetChallengeDetailsQuery : IRequest<ChallengeDetailsDto>
    {
        public Guid EventId { get; set; }

        public Guid Id { get; set; }
    }

    public class GetChallengeDetailsQueryHandler : IRequestHandler<GetChallengeDetailsQuery, ChallengeDetailsDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetChallengeDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ChallengeDetailsDto> Handle(GetChallengeDetailsQuery request, CancellationToken cancellationToken)
        {
            var challenge = await _context.Challenges.Include(q=>q.Questions).Include(q=>q.Event).FirstOrDefaultAsync(q=>q.Id == request.Id, cancellationToken);

            if(challenge == null)
            {
                throw new NotFoundException(nameof(Challenge), request.Id);
            }

            return _mapper.Map<ChallengeDetailsDto>(challenge);
        }
    }
}

using AutoMapper;
using FindExactSolution.Application.Common.Interfaces;
using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Area.Admin.Challenges.Commands.CreateChallenge
{
    public class CreateChallengeCommand : IRequest<Guid>, IMapFrom<Challenge>
    {
        public Guid EventId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int Order { get; set; }
    }

    public class CreateChallengeCommandHandler : IRequestHandler<CreateChallengeCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateChallengeCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateChallengeCommand request, CancellationToken cancellationToken)
        {
            var challenge = _mapper.Map<Challenge>(request);

            await _context.Challenges.AddAsync(challenge, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return challenge.Id;
        }
    }
}

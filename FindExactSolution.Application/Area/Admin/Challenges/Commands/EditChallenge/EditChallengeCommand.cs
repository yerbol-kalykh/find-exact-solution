using AutoMapper;
using FindExactSolution.Application.Common.Exceptions;
using FindExactSolution.Application.Common.Interfaces;
using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Area.Admin.Challenges.Commands.EditChallenge
{
    public class EditChallengeCommand : IRequest, IMapFrom<Challenge>
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
    }

    public class EditChallengeCommandHandler : IRequestHandler<EditChallengeCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EditChallengeCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(EditChallengeCommand request, CancellationToken cancellationToken)
        {
            var challenge = await _context.Challenges.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);

            if (challenge == null)
            {
                throw new NotFoundException(nameof(Challenge), request.Id);
            }

            _mapper.Map(request, challenge);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

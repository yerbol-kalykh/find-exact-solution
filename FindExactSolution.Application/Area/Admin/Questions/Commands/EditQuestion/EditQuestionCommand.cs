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

namespace FindExactSolution.Application.Area.Admin.Questions.Commands.EditQuestion
{
    public class EditQuestionCommand : IRequest, IMapFrom<Question>
    {
        public Guid Id { get; set; }
        public Guid ChallengeId { get; set; }
        public string Description { get; set; }
        public string Input { get; set; }
        public string Answer { get; set; }
        public int Point { get; set; }
    }

    public class EditQuestionCommandHandler : IRequestHandler<EditQuestionCommand>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        public EditQuestionCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(EditQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await _context.Questions.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);

            if (question == null)
            {
                throw new NotFoundException(nameof(Question), request.Id);
            }

            _mapper.Map(request, question);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

using AutoMapper;
using FindExactSolution.Application.Common.Interfaces;
using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Area.Admin.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommand : IRequest<Guid>, IMapFrom<Question>
    {
        public Guid EventId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int Point { get; set; }

        public int Order { get; set; }

        public string Input { get; set; }

        public string Answer { get; set; }
    }

    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateQuestionCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = _mapper.Map<Question>(request);

            await _context.Questions.AddAsync(question, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return question.Id;
        }
    }
}

using FindExactSolution.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Questions.Command.SubmitAnswer
{
    public class SubmitAnswerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public string Answer { get; set; }
    }

    public class SubmitAnswerCommandHandler : IRequestHandler<SubmitAnswerCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public SubmitAnswerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(SubmitAnswerCommand request, CancellationToken cancellationToken)
        {
            var question = await _context.Questions.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (question.Answer != request.Answer) return false;

            return true;
        }
    }
}

using FindExactSolution.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.QuestionSubmissions.Command.SubmitAnswer
{
    public class SubmitAnswerCommandValidator : AbstractValidator<SubmitAnswerCommand>
    {
        private readonly IApplicationDbContext _context;

        public SubmitAnswerCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.EventId).MustAsync(EventExists).WithMessage("The specified event does not exists.")
                                   .MustAsync(EventIsOpen).WithMessage("The specified event is closed.");
        }

        public async Task<bool> EventExists(SubmitAnswerCommand command, Guid eventId, CancellationToken cancellationToken)
        {
            return await _context.Events.AnyAsync(e => e.Id == eventId, cancellationToken);
        }

        public async Task<bool> EventIsOpen(SubmitAnswerCommand command, Guid eventId, CancellationToken cancellationToken)
        {
            var eventEntity = await _context.Events.FirstOrDefaultAsync(e => e.Id == eventId, cancellationToken);

            return eventEntity.IsOpen;
        }
    }
}

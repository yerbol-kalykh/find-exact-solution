using FindExactSolution.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Registrations.Commands
{
    public class CreateRegistrationCommandValidator : AbstractValidator<CreateRegistrationCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateRegistrationCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.EventId)
                   .MustAsync(EventExists).WithMessage("The specified event does not exists."); ;
        }

        public async Task<bool> EventExists(CreateRegistrationCommand model, Guid eventId, CancellationToken cancellationToken)
        {
            return await _context.Events.AnyAsync(e => e.Id == eventId);
        }
    }
}

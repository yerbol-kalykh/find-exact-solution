using FindExactSolution.Application.Common.Exceptions;
using FindExactSolution.Application.Common.Interfaces;
using FindExactSolution.Domain.Entities;
using FindExactSolution.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Registrations.Commands
{
    public class CreateRegistrationCommand : IRequest<Guid>
    {
        public Guid EventId { get; set; }
    }


    public class CreateRegistrationCommandHandle : IRequestHandler<CreateRegistrationCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _userService;

        public CreateRegistrationCommandHandle(IApplicationDbContext context, ICurrentUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<Guid> Handle(CreateRegistrationCommand request, CancellationToken cancellationToken)
        {
            var registrationExists = await _context.Registrations.AnyAsync(r => r.EventId == request.EventId
                                        && r.UserId == _userService.UserId
                                        && r.Status == RegistrationStatus.Registered, cancellationToken);

            if (registrationExists)
            {
                throw new Exception("You have already registered.");
            }

            var registration = new Registration()
            {
                EventId = request.EventId,
                UserId = _userService.UserId,
                Status = RegistrationStatus.Registered
            };

            await _context.Registrations.AddAsync(registration, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return registration.Id;
        }
    }
}

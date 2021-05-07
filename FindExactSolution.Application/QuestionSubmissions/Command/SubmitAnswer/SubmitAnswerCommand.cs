using FindExactSolution.Application.Common.Exceptions;
using FindExactSolution.Application.Common.Interfaces;
using FindExactSolution.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.QuestionSubmissions.Command.SubmitAnswer
{
    public class SubmitAnswerCommand : IRequest<bool>
    {
        public Guid QuestionId { get; set; }

        public Guid EventId { get; set; }

        public string Answer { get; set; }
    }

    public class SubmitAnswerCommandHandler : IRequestHandler<SubmitAnswerCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public SubmitAnswerCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<bool> Handle(SubmitAnswerCommand request, CancellationToken cancellationToken)
        {
            var team = await _context.Teams
                            .FirstOrDefaultAsync(t=>t.EventId == request.EventId 
                            && t.Users.Any(u=>u.Id == _currentUserService.UserId), cancellationToken);

            if(team == null)
            {
                throw new NotFoundException(nameof(Question), request.QuestionId);
            }

            var question = await _context.Questions.FirstOrDefaultAsync(q => q.Id == request.QuestionId, cancellationToken);

            var isCorrect = question.Answer == request.Answer;

            var submission = await _context.QuestionSubmissions
                                   .FirstOrDefaultAsync(qs => qs.QuestionId == request.QuestionId
                                   && qs.TeamId == qs.TeamId, cancellationToken);
            
            if(submission == null)
            {
                submission = QuestionSubmission.Create(request.QuestionId, team.Id, isCorrect);

                await _context.QuestionSubmissions.AddAsync(submission, cancellationToken);
            }
            else
            {
                submission.Update(isCorrect); 
            }

            await _context.SaveChangesAsync(cancellationToken);

            return isCorrect;
        }
    }
}
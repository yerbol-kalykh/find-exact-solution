using AutoMapper;
using FindExactSolution.Application.Challenges.Models;
using FindExactSolution.Application.Common.Exceptions;
using FindExactSolution.Application.Common.Interfaces;
using FindExactSolution.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.QuestionSubmissions.Command.SubmitAnswer
{
    public class SubmitAnswerCommand : IRequest<QuestionSubmissionChallengeDto>
    {
        public Guid QuestionId { get; set; }

        public Guid EventId { get; set; }

        public string Answer { get; set; }
    }

    public class SubmitAnswerCommandHandler : IRequestHandler<SubmitAnswerCommand, QuestionSubmissionChallengeDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public SubmitAnswerCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService, IMapper mapper)
        {
            _context = context;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<QuestionSubmissionChallengeDto> Handle(SubmitAnswerCommand request, CancellationToken cancellationToken)
        {
            var team = await _context.Teams.Include(t=>t.QuestionSubmissions)
                                           .Include(t => t.Users)
                                           .FirstOrDefaultAsync(t => t.EventId == request.EventId 
                                           && t.Users.Any(u => u.Id == _currentUserService.UserId), cancellationToken);

            if (team == null)
            {
                throw new NotFoundException("Team was not found for current user");
            }

            var question = await _context.Questions.Include(q=>q.Challenge)
                                                        .ThenInclude(c=>c.Questions)
                                                   .FirstOrDefaultAsync(q => q.Id == request.QuestionId, cancellationToken);

            var isCorrect = question.Answer == request.Answer;

            // Create or update submission
            var submissions = await _context.QuestionSubmissions.Where(qs => qs.QuestionId == request.QuestionId).ToListAsync(cancellationToken);

            var calculatedPoints = isCorrect ? CalculatePoints(submissions, question.Point) : 0;

            var submission = submissions.FirstOrDefault(qs => qs.TeamId == team.Id);

            if (submission == null)
            {
                submission = QuestionSubmission.Create(request.QuestionId, team.Id, isCorrect, request.Answer, calculatedPoints);

                await _context.QuestionSubmissions.AddAsync(submission, cancellationToken);
            }
            else
            {
                if (submission.IsCorrect) return _mapper.Map<QuestionSubmissionChallengeDto>(submission);

                submission.Update(isCorrect, request.Answer, calculatedPoints);
            }

            if (submission.IsCorrect)
            {
                await UpdateTeamResultAsync(request.EventId, team, submission, question);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<QuestionSubmissionChallengeDto>(submission);
        }

        private async Task UpdateTeamResultAsync(Guid eventId, Team team, QuestionSubmission submission, Question question)
        {
            var result = await _context.Results.FirstOrDefaultAsync(r => r.EventId == eventId && r.TeamId == team.Id);

            result.TotalPoints += submission.EarnedPoints;

            if (submission.IsCorrect) result.SolvedQuestions++;

            if (team.QuestionSubmissions.Count(qs => qs.IsCorrect) == question.Challenge.Questions.Count) result.SolvedChallenges++;
        }

        private static int CalculatePoints(List<QuestionSubmission> submissions, int point)
        {
            return point + Math.Max(2 - submissions.Count(s => s.IsCorrect), 0);
        }
    }
}
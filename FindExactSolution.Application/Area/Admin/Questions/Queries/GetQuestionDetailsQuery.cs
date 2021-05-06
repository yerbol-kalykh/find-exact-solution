using AutoMapper;
using FindExactSolution.Application.Area.Admin.Questions.Models;
using FindExactSolution.Application.Common.Exceptions;
using FindExactSolution.Application.Common.Interfaces;
using FindExactSolution.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Area.Admin.Questions.Queries
{
    public class GetQuestionDetailsQuery : IRequest<QuestionDetailsDto>
    {
        public Guid ChallengeId { get; set; }

        public Guid Id { get; set; }
    }

    public class GetQuestionDetailsQueryHandler : IRequestHandler<GetQuestionDetailsQuery, QuestionDetailsDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetQuestionDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QuestionDetailsDto> Handle(GetQuestionDetailsQuery request, CancellationToken cancellationToken)
        {
            var question = await _context.Questions.Include(p => p.Challenge).FirstOrDefaultAsync(q => q.Id == request.Id, cancellationToken);

            if (question == null)
            {
                throw new NotFoundException(nameof(Question), request.Id);
            }

            return _mapper.Map<QuestionDetailsDto>(question);
        }
    }
}

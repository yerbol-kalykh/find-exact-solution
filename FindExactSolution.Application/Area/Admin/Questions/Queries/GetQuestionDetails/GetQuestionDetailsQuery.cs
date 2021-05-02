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

namespace FindExactSolution.Application.Area.Admin.Questions.Queries.GetQuestionDetails
{
    public class GetQuestionDetailsQuery : IRequest<QuestionDetailsDto>
    {
        public Guid EventId { get; set; }

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
            var questionEntity = await _context.Questions.Include(q=>q.Event).FirstOrDefaultAsync(q=>q.Id == request.Id, cancellationToken);

            if(questionEntity == null)
            {
                throw new NotFoundException(nameof(Question), request.Id);
            }

            return _mapper.Map<QuestionDetailsDto>(questionEntity);
        }
    }
}

﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using FindExactSolution.Application.Common.Interfaces;
using FindExactSolution.Application.Questions.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FindExactSolution.Application.Questions.Queries.GetEventQuestions
{
    public class GetEventQuestionsQuery : IRequest<IEnumerable<QuestionDto>>
    {
        public Guid EventId { get; set; }
    }

    public class GetEventQuestionsQueryHandler : IRequestHandler<GetEventQuestionsQuery, IEnumerable<QuestionDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetEventQuestionsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuestionDto>> Handle(GetEventQuestionsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Questions.AsNoTracking()
                                           .Where(q=>q.EventId == request.EventId)
                                           .ProjectTo<QuestionDto>(_mapper.ConfigurationProvider)
                                           .ToListAsync(cancellationToken);
        }
    }
}
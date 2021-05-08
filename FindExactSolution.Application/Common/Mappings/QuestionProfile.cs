using AutoMapper;
using FindExactSolution.Application.Area.Admin.Challenges.Models;
using FindExactSolution.Application.Area.Admin.Questions.Commands.CreateQuestion;
using FindExactSolution.Application.Area.Admin.Questions.Commands.EditQuestion;
using FindExactSolution.Application.Challenges.Models;
using FindExactSolution.Domain.Entities;
using System.Linq;

namespace FindExactSolution.Application.Common.Mappings
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<CreateQuestionCommand, Question>();

            CreateMap<EditQuestionCommand, Question>();

            CreateMap<Question, QuestionChallengeDto>()
                     .ForMember(qc => qc.QuestionSubmission, src => src.MapFrom(q => q.QuestionSubmissions.FirstOrDefault()));
        }
    }
}

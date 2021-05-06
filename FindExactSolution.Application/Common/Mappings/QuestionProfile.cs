using AutoMapper;
using FindExactSolution.Application.Area.Admin.Questions.Commands.CreateQuestion;
using FindExactSolution.Application.Area.Admin.Questions.Commands.EditQuestion;
using FindExactSolution.Domain.Entities;

namespace FindExactSolution.Application.Common.Mappings
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<CreateQuestionCommand, Question>();

            CreateMap<EditQuestionCommand, Question>();
        }
    }
}

using AutoMapper;
using FindExactSolution.Web.Client.Common.Resources.Questions;
using FindExactSolution.Web.Client.Common.Resources.QuestionSubmissions;

namespace FindExactSolution.Web.Client.Common.Mappings
{
    public class QuestionSubmissionProfile : Profile
    {
        public QuestionSubmissionProfile()
        {
            CreateMap<QuestionChallengeResource, SubmitAnswerResource>()
                     .ForMember(s => s.QuestionId, src => src.MapFrom(q => q.Id))
                     .ForMember(s => s.Answer, src => src.MapFrom(q => q.QuestionSubmission == null ? null : q.QuestionSubmission.TeamAnswer));
        }
    }
}

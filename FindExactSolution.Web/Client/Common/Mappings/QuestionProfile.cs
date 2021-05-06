using AutoMapper;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Questions;
using FindExactSolution.Web.Client.Common.Resources.Questions;

namespace FindExactSolution.Web.Client.Common.Mappings
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<AdminQuestionDetailsResource, AdminQuestionEditResource>();

            CreateMap<QuestionChallengeResource, QuestionSubmitResource>();
        }
    }
}

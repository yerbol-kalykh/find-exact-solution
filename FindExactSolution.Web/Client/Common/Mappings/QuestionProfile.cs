using AutoMapper;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Questions;

namespace FindExactSolution.Web.Client.Common.Mappings
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<AdminQuestionDetailsResource, AdminQuestionEditResource>();
        }
    }
}

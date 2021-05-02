using AutoMapper;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Questions;
using FindExactSolution.Web.Client.Common.Resources.Questions;

namespace FindExactSolution.Web.Client.Common.Mappings
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<AdminQuestionDetailsResource, EditQuestionResource>()
                      .ForMember(e=>e.EventId, src => src.MapFrom(q=>q.Event.Id));
        }
    }
}

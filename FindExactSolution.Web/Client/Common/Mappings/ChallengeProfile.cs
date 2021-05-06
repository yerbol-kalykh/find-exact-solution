using AutoMapper;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Challenges;

namespace FindExactSolution.Web.Client.Common.Mappings
{
    public class ChallengeProfile : Profile
    {
        public ChallengeProfile()
        {
            CreateMap<AdminChallengeDetailsResource, AdminChallengeEditResource>()
                      .ForMember(e => e.EventId, src => src.MapFrom(q => q.Event.Id));
        }
    }
}

using AutoMapper;
using FindExactSolution.Application.Area.Admin.Events.Models;
using FindExactSolution.Domain.Entities;

namespace FindExactSolution.Application.Common.Mappings
{
    public class RegistrationProfile : Profile
    {
        public RegistrationProfile()
        {
            CreateMap<Registration, RegistrationEventDto>()
                     .ForMember(er => er.FirstName, src => src.MapFrom(r => r.User.FirstName))
                     .ForMember(er => er.LastName, src => src.MapFrom(r => r.User.LastName))
                     .ForMember(er => er.Email, src => src.MapFrom(r => r.User.Email))
                     .ForMember(er => er.UserName, src => src.MapFrom(r => r.User.UserName));
        }
    }
}

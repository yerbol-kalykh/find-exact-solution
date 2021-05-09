using AutoMapper;
using FindExactSolution.Application.Area.Admin.Events.Models;
using FindExactSolution.Application.Area.Admin.Results.Models;
using FindExactSolution.Application.Events.Models;
using FindExactSolution.Domain.Entities;

namespace FindExactSolution.Application.Common.Mappings
{
    public class ResultProfile : Profile
    {
        public ResultProfile()
        {
            CreateMap<Result, AdminResultEventDto>()
                        .ForMember(ar => ar.TeamName, src => src.MapFrom(r => r.Team.Name));

            CreateMap<AdminResultDto, Result>();

            CreateMap<Result, ResultEventDto>()
                        .ForMember(ar => ar.TeamName, src => src.MapFrom(r => r.Team.Name));
        }
    }
}

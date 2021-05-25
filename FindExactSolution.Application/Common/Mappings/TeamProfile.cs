using AutoMapper;
using FindExactSolution.Application.Area.Admin.Events.Models;
using FindExactSolution.Application.Area.Admin.Teams.Models;
using FindExactSolution.Application.Teams.Commands.EditTeam;
using FindExactSolution.Domain.Entities;

namespace FindExactSolution.Application.Common.Mappings
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, AdminTeamEventDto>()
                    .ForMember(at=>at.TotalMembers, src=>src.MapFrom(t=>t.Users.Count));

            CreateMap<Team, AdminTeamDto>()
              .ForMember(at => at.TotalMembers, src => src.MapFrom(t => t.Users.Count));

            CreateMap<EditTeamCommand, Team>();
        }
    }
}
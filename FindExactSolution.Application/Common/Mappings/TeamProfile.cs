using AutoMapper;
using FindExactSolution.Application.Teams.Commands.EditTeam;
using FindExactSolution.Domain.Entities;

namespace FindExactSolution.Application.Common.Mappings
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<EditTeamCommand, Team>();
        }
    }
}
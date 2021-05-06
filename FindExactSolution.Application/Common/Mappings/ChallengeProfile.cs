using AutoMapper;
using FindExactSolution.Application.Area.Admin.Challenges.Commands.CreateChallenge;
using FindExactSolution.Application.Area.Admin.Challenges.Commands.EditChallenge;
using FindExactSolution.Application.Challenges.Models;
using FindExactSolution.Domain.Entities;
using System.Linq;

namespace FindExactSolution.Application.Common.Mappings
{
    public class ChallengeProfile : Profile
    {
        public ChallengeProfile()
        {
            CreateMap<CreateChallengeCommand, Challenge>();

            CreateMap<EditChallengeCommand, Challenge>();

            CreateMap<Challenge, ChallengeDto>()
                     .ForMember(q => q.Point, src => src.MapFrom(q => q.Questions.Sum(p => p.Point)));
        }
    }
}
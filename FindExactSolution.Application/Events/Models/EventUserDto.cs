using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Common;
using System;

namespace FindExactSolution.Application.Events.Models
{
    public class EventUserDto : IMapFrom<IUser>
    {
        public Guid Id { get; set; }
    }
}
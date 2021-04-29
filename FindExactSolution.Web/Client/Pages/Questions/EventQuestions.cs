using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Pages.Questions
{
    public partial class EventQuestions
    {
        [Parameter]
        public Guid EventId { get; set; }

        protected override async Task OnInitializedAsync()
        {

        }
    }
}

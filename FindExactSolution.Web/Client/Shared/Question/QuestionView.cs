using FindExactSolution.Web.Client.Common.Resources.Questions;
using Microsoft.AspNetCore.Components;

namespace FindExactSolution.Web.Client.Shared.Question
{
    public partial class QuestionView
    {
        [Parameter]
        public QuestionResource SelectedQuestion { get; set; }
    }
}
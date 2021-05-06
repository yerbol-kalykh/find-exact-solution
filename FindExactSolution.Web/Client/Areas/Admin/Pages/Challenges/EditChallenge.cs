using AutoMapper;
using FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Challenges;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Areas.Admin.Pages.Challenges
{
    public partial class EditChallenge
    {
        [Parameter]
        public Guid EventId { get; set; }

        [Parameter]
        public Guid Id { get; set; }

        [Inject]
        public IAdminEventService AdminEventService { get; set; }

        [Inject]
        public IAdminChallengeService AdminChallengeService { get; set; }

        [Inject]
        public NavigationManager UriHelper { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public IMapper Mapper { get; set; } 

        public ElementReference DivEditorElement { get; set; }

        public AdminChallengeEditResource AdminChallengeEditResource { get; set; } = new AdminChallengeEditResource();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var challengeDetail = await AdminChallengeService.GetChallengeDetailsAsync(EventId, Id);

                if (challengeDetail == null) UriHelper.NavigateTo($"/admin/events");
                else
                {
                    Mapper.Map(challengeDetail, AdminChallengeEditResource);

                    await JSRuntime.InvokeAsync<object>("QuillFunctions.loadQuillHTMLContent", DivEditorElement, challengeDetail.Body);
                }
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeAsync<string>("QuillFunctions.createQuill", DivEditorElement);
            }
        }

        protected async Task HandleValidSubmit()
        {
            AdminChallengeEditResource.Body = await JSRuntime.InvokeAsync<string>("QuillFunctions.getQuillHTML", DivEditorElement);

            await AdminChallengeService.UpdateChallengeAsync(AdminChallengeEditResource);

            UriHelper.NavigateTo($"/admin/events/{EventId}/challenges/{Id}");
        }

        public void Cancel()
        {
            UriHelper.NavigateTo($"/admin/events/{EventId}");
        }
    }
}

using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Pages.Skills
{
    public partial class SkillTypePage
    {
        [Parameter]
        public required string typeName { get; set; }

        private bool dataLoaded => (skills is not null);
        private bool notFound = false;

        private Skill[]? skills;

        protected override async Task OnParametersSetAsync()
        {
            var _typeName = Uri.UnescapeDataString(typeName);

            skills = await DataService.GetSkillsByTypeAsync(_typeName);

            notFound = (skills is null);
        }
    }
}

using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Pages.Skills
{
    public partial class SkillAttributePage
    {
        [Parameter]
        public required string attrName { get; set; }

        private bool dataLoaded => (skills is not null);
        private bool notFound = false;

        private Skill[]? skills;

        protected override async Task OnParametersSetAsync()
        {
            var _attrName = Uri.UnescapeDataString(attrName);

            skills = await DataService.GetSkillsByAttributeAsync(_attrName);

            notFound = (skills is null);
        }
    }
}

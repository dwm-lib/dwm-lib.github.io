using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Pages.Skills
{
    public partial class SkillCategoryPage
    {
        [Parameter]
        public required string categoryName { get; set; }

        private bool dataLoaded => (skills is not null);
        private bool notFound = false;

        private Skill[]? skills;

        protected override async Task OnParametersSetAsync()
        {
            var _categoryName = Uri.UnescapeDataString(categoryName);

            skills = await DataService.GetSkillsByCategoryAsync(_categoryName);

            notFound = (skills is null);
        }
    }
}

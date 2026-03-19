using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Pages.Skills
{
    public partial class SkillCategoryPage
    {
        [Parameter]
        public required string CategoryName { get; set; }

        private bool dataLoaded => (skills is not null);

        private Skill[]? skills;

        protected override async Task OnParametersSetAsync()
        {
            CategoryName = Uri.UnescapeDataString(CategoryName);

            if (Enum.IsDefined(typeof(SkillCategory), CategoryName) || Enum.IsDefined(typeof(SkillCategory), int.Parse(CategoryName)))
            {
                var _category = Enum.Parse<SkillCategory>(CategoryName);
                CategoryName = _category.ToJsonString();
                skills = await DataService.GetSkillsByCategoryAsync(_category);
            }

            if (!dataLoaded)
            {
                NavigationManager.NavigateTo("/404");
            }
        }
    }
}

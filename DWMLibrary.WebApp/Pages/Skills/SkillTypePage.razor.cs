using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Pages.Skills
{
    public partial class SkillTypePage
    {
        [Parameter]
        public required string TypeName { get; set; }

        private bool dataLoaded => (skills is not null);

        private Skill[]? skills;

        protected override async Task OnParametersSetAsync()
        {
            TypeName = Uri.UnescapeDataString(TypeName);

            if (Enum.IsDefined(typeof(SkillType), TypeName) || Enum.IsDefined(typeof(SkillType), int.Parse(TypeName)))
            {
                var _type = Enum.Parse<SkillType>(TypeName);
                TypeName = _type.ToJsonString();
                skills = await DataService.GetSkillsByTypeAsync(_type);
            }

            if (!dataLoaded)
            {
                NavigationManager.NavigateTo("/404");
            }
        }
    }
}

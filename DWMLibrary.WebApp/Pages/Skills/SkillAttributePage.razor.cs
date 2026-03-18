using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Pages.Skills
{
    public partial class SkillAttributePage
    {
        [Parameter]
        public required string AttributeName { get; set; }

        private bool dataLoaded => (skills is not null);
        private bool notFound = false;

        private Skill[]? skills;

        protected override async Task OnParametersSetAsync()
        {
            AttributeName = Uri.UnescapeDataString(AttributeName);

            if (Enum.IsDefined(typeof(SkillAttribute), AttributeName) || Enum.IsDefined(typeof(SkillAttribute), int.Parse(AttributeName)))
            {
                var _attribute = Enum.Parse<SkillAttribute>(AttributeName);
                AttributeName = _attribute.ToJsonString();
                skills = await DataService.GetSkillsByAttributeAsync(_attribute);
            }

            notFound = (skills is null);
        }
    }
}

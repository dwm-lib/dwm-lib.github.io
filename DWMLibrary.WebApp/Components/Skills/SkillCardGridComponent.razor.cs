using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Components.Skills;

public partial class SkillCardGridComponent
{
    [Parameter]
    public required Skill[]? skills { get; set; }

    private bool dataLoaded => skills is not null && skills.Length > 0;
}

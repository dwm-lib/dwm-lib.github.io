using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Components.Skills;

public partial class SkillRequirementsComponent
{
    [Parameter]
    public required Skill[]? skills { get; set; }

    [Parameter]
    public required bool includeNames { get; set; } = false;

    private bool dataLoaded => skills is not null && skills.Length > 0;
}

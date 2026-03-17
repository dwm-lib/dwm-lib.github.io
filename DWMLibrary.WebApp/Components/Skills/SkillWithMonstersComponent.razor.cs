using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Components.Skills;

public partial class SkillWithMonstersComponent
{
    [Parameter]
    public required Skill skill { get; set; }

    [Parameter]
    public bool isCurrent { get; set; } = false;

    [Parameter]
    public bool isRelevant { get; set; } = false;

    [Parameter]
    public bool showMonsters { get; set; } = true;
}

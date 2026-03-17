using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Components.Monsters;

public partial class MonsterInfoComponent
{
    [Parameter]
    public required Monster? monster { get; set; }

    private bool dataLoaded => monster is not null;
}

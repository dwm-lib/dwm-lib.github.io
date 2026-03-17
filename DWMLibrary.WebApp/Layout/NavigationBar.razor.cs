using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Layout;

public partial class NavigationBar
{
    [Parameter]
    public required EventCallback<bool> OnClickCallback { get; set; }

    [CascadingParameter]
    public bool CollapseNavMenu { get; set; } = true;

    private string? NavMenuCssClass => CollapseNavMenu ? "collapse" : null;

    private async Task CloseNavMenu()
    {
        CollapseNavMenu = true;
        await OnClickCallback.InvokeAsync(CollapseNavMenu);
    }

    private async Task ToggleNavMenu()
    {
        CollapseNavMenu = !CollapseNavMenu;
        await OnClickCallback.InvokeAsync(CollapseNavMenu);
    }
}
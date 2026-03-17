using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Layout;

public partial class BreadcrumbBar
{
    [Parameter]
    public required EventCallback<bool> OnClickCallback { get; set; }

    [Parameter]
    public Tuple<string, string>[]? Links { get; set; }

    [CascadingParameter]
    public required bool CollapseNavMenu { get; set; } = true;

    private async Task CloseNavMenu()
    {
        await OnClickCallback.InvokeAsync(true);
    }
}
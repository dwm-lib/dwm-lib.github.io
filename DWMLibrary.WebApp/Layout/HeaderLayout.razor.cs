using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Layout;

public partial class HeaderLayout
{
    [Parameter]
    public required OrderedDictionary<string, string> BreadcrumbLinks { get; set; }

    private static Tuple<string, string>[] NavigationLinks =>
    [
        new("monster", "Monsters"),
        new("skill", "Skills"),
        new("about", "About"),
        new("json", "Json")
    ];
}
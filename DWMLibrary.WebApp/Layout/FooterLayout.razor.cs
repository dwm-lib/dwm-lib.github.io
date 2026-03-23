using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Layout;

public partial class FooterLayout
{
    [Parameter]
    public required Dictionary<string, int> DataCounts { get; set; }

    private int Monsters => DataCounts.GetValueOrDefault(nameof(Monster));
    private int Skills => DataCounts.GetValueOrDefault(nameof(Skill));
    private int Breeds => DataCounts.GetValueOrDefault(nameof(Breed));

    private static Tuple<string, string>[] NavigationLinks =>
    [
        new(string.Empty, "Home"),
        new("monster", "Monsters"),
        new("monster/family", "Families"),
        new("monster/location", "Locations"),
        new("skill", "Skills"),
        new("skill/type", "Types"),
        new("skill/attribute", "Attributes"),
        new("about", "About"),
        new("json", "Json")
    ];
}
using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Layout;

public partial class MainLayout
{
    private ErrorBoundary? ErrorBoundary { get; set; }

    private readonly OrderedDictionary<string, string> BreadcrumbLinks = [];
    private readonly Dictionary<string, int> DataCounts = [];

    protected override async Task OnParametersSetAsync()
    {
        ErrorBoundary?.Recover();

        GetBreadcrumbLinks();

        await GetDataCounts();

        base.OnParametersSet();
    }

    private void GetBreadcrumbLinks()
    {
        var currentUrl = NavigationManager.Uri;
        var myUrl = currentUrl.Replace(NavigationManager.BaseUri, "");
        var path = myUrl.Split('/');
        var lastLink = string.Empty;

        BreadcrumbLinks.Clear();
        BreadcrumbLinks.Add("home", lastLink);
        foreach (var link in path.Where(p => !string.IsNullOrWhiteSpace(p)))
        {
            lastLink = $"{lastLink}/{link}";
            BreadcrumbLinks.Add(Uri.UnescapeDataString(link), lastLink);
        }
    }

    private async Task GetDataCounts()
    {
        if (!DataCounts.ContainsKey(nameof(Monster)))
        {
            var count = (await DataService.GetMonstersAsync())?.Length ?? 0;
            DataCounts.Add(nameof(Monster), count);
        }

        if (!DataCounts.ContainsKey(nameof(Skill)))
        {
            var count = (await DataService.GetSkillsAsync())?.Length ?? 0;
            DataCounts.Add(nameof(Skill), count);
        }

        if (!DataCounts.ContainsKey(nameof(Breed)))
        {
            var count = (await DataService.GetBreedsAsync())?.Length ?? 0;
            DataCounts.Add(nameof(Breed), count);
        }
    }
}
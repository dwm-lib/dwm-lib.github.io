namespace DWMLibrary.WebApp.Layout;

public partial class StatisticsBar
{
    private bool dataLoaded => (breeds is not null && breeds.Length > 0 && monsters is not null && monsters.Length > 0 && skills is not null && skills.Length > 0);

    private Breed[]? breeds;
    private Monster[]? monsters;
    private Skill[]? skills;

    protected override async Task OnInitializedAsync()
    {
        breeds = await DataService.GetBreedsAsync();
        monsters = await DataService.GetMonstersAsync();
        skills = await DataService.GetSkillsAsync();
    }
}
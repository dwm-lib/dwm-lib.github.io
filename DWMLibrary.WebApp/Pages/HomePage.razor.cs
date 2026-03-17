namespace DWMLibrary.WebApp.Pages;

public partial class HomePage
{
    private bool dataLoaded => (breeds is not null && breeds.Length > 0 && monsters is not null && monsters.Length > 0 && skills is not null && skills.Length > 0);
    private bool notFound = false;

    private Core.Models.Breed[]? breeds;
    private Core.Models.Monster[]? monsters;
    private Core.Models.Skill[]? skills;

    protected override async Task OnInitializedAsync()
    {
        breeds = await DataService.GetBreedsAsync();
        monsters = await DataService.GetMonstersAsync();
        skills = await DataService.GetSkillsAsync();

        notFound = (breeds is null || monsters is null || skills is null);
    }
}

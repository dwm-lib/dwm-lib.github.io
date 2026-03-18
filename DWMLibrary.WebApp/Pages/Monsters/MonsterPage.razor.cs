using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Pages.Monsters
{
    public partial class MonsterPage
    {
        [Parameter]
        public required string monsterName { get; set; }

        private bool dataLoaded => (monster is not null && breeds is not null);
        private bool notFound = false;

        private Monster? monster;
        private Breed[]? breeds;

        protected override async Task OnParametersSetAsync()
        {
            monsterName = Uri.UnescapeDataString(monsterName);

            monster = await DataService.GetMonsterByNameAsync(monsterName);
            breeds = (await DataService.GetBreedsByMonsterAsync(monsterName)) ?? [];

            notFound = (monster is null);
        }
    }
}

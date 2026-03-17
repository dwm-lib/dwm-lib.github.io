using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Pages.Monsters
{
    public partial class MonsterRarityPage
    {
        [Parameter]
        public required string rarityName { get; set; }

        private bool dataLoaded => (monsters is not null && breeds is not null);
        private bool notFound = false;

        private Monster[]? monsters;
        private Breed[]? breeds;

        protected override async Task OnParametersSetAsync()
        {
            var _rarityName = Uri.UnescapeDataString(rarityName);

            monsters = await DataService.GetMonstersByRarityAsync(_rarityName);
            breeds = (await DataService.GetBreedsByRarityAsync(_rarityName)) ?? [];

            notFound = (monsters is null);
        }
    }
}

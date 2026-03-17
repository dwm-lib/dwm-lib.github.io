using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Pages.Monsters
{
    public partial class MonsterSizePage
    {
        [Parameter]
        public required string sizeName { get; set; }

        private bool dataLoaded => (monsters is not null && breeds is not null);
        private bool notFound = false;

        private Monster[]? monsters;
        private Breed[]? breeds;

        protected override async Task OnParametersSetAsync()
        {
            var _sizeName = Uri.UnescapeDataString(sizeName);

            monsters = await DataService.GetMonstersBySizeAsync(_sizeName);
            breeds = (await DataService.GetBreedsBySizeAsync(_sizeName)) ?? [];

            notFound = (monsters is null);
        }
    }
}

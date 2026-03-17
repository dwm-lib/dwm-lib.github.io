using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Pages.Monsters
{
    public partial class MonsterFamilyPage
    {
        [Parameter]
        public required string familyName { get; set; }

        private bool dataLoaded => (monsters is not null && breeds is not null);
        private bool notFound = false;

        private Monster[]? monsters;
        private Breed[]? breeds;

        protected override async Task OnParametersSetAsync()
        {
            var _familyName = Uri.UnescapeDataString(familyName);
            monsters = await DataService.GetMonstersByFamilyAsync(_familyName);
            breeds = (await DataService.GetBreedsByFamilyAsync(_familyName)) ?? [];

            notFound = (monsters is null);
        }
    }
}

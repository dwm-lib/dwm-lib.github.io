using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Pages.Monsters
{
    public partial class MonsterLocationPage
    {
        [Parameter]
        public required string locationName { get; set; }

        private bool dataLoaded => (monsters is not null && breeds is not null);
        private bool notFound = false;

        private Monster[]? monsters;
        private Breed[]? breeds;

        protected override async Task OnParametersSetAsync()
        {
            var _locationName = Uri.UnescapeDataString(locationName);

            monsters = await DataService.GetMonstersByLocationAsync(_locationName);
            breeds = (await DataService.GetBreedsByLocationAsync(_locationName)) ?? [];

            notFound = (monsters is null);
        }

        private Monster[] GetMonstersForVersion(MonsterLocationVersion version)
        {
            return monsters!.Where(monster =>
            {
                return monster.Locations.Any(location =>
                    {
                        return location.Version == version && string.Equals(location.Name.ToJsonString(), Uri.UnescapeDataString(locationName), StringComparison.InvariantCultureIgnoreCase);
                    });
            }).OrderBy(monster => monster.Id).ToArray();
        }
    }
}

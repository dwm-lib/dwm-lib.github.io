using Microsoft.AspNetCore.Components;

namespace DWMLibrary.WebApp.Pages.Monsters
{
    public partial class MonsterFamilyPage
    {
        [Parameter]
        public required string FamilyName { get; set; }

        private bool dataLoaded => (monsters is not null && breeds is not null);
        private bool notFound = false;

        private Monster[]? monsters;
        private Breed[]? breeds;

        protected override async Task OnParametersSetAsync()
        {
            FamilyName = Uri.UnescapeDataString(FamilyName);

            if (Enum.IsDefined(typeof(MonsterFamily), FamilyName) || Enum.IsDefined(typeof(MonsterFamily), int.Parse(FamilyName)))
            {
                var _family = Enum.Parse<MonsterFamily>(FamilyName);
                FamilyName = _family.ToJsonString();
                monsters = await DataService.GetMonstersByFamilyAsync(_family);
                breeds = (await DataService.GetBreedsByFamilyAsync(_family)) ?? [];
            }

            notFound = (monsters is null);
        }
    }
}

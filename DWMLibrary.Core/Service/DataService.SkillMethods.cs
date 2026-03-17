namespace DWMLibrary.Core;

public partial class DataService : IDataService
{
    public async Task<Skill[]?> GetSkillsAsync(CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return Data?.Skills?.OrderBy(skill => skill.Id).ToArray();
    }

    public async Task<Skill?> GetSkillByNameAsync(string skillName, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return Data?.Skills.FirstOrDefault(skill => string.Equals(skill.Name, skillName, StringComparison.InvariantCultureIgnoreCase));
    }

    public async Task<Skill[]?> GetSkillsByTypeAsync(string typeName, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return Data?.Skills.Where(skill => string.Equals(skill.Type.ToString(), typeName, StringComparison.InvariantCultureIgnoreCase)).OrderBy(skill => skill.Id).ToArray();
    }

    public async Task<Skill[]?> GetSkillsByAttributeAsync(string attributeName, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return Data?.Skills.Where(skill => string.Equals(skill.Attribute.ToString(), attributeName, StringComparison.InvariantCultureIgnoreCase)).OrderBy(skill => skill.Id).ToArray();
    }

    public async Task<Skill[]?> GetSkillsByCategoryAsync(string categoryName, CancellationToken cancellationToken = default)
    {
        if (DATA_NOT_LOADED)
            await LoadLibraryDataFromJsonAsync(cancellationToken);

        return Data?.Skills.Where(skill => string.Equals(skill.Category.ToString(), categoryName, StringComparison.InvariantCultureIgnoreCase)).OrderBy(skill => skill.Id).ToArray();
    }
}

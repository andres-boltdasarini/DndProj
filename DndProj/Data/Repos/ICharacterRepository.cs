using DndProj.Contracts.Models.Character;

namespace DndProj.Data.Repos
{
    public interface ICharacterRepository
    {
        Task<string> GetCharacterFileContentAsync(string fileName);
        Task<string> SaveCharacterAsync(AddCharacterRequest request);
        bool IsValidFileName(string fileName);
    }
}

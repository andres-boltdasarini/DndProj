using DndProj.Contracts.Models.Character;

namespace DndProj.Data.Repos
{
    public interface ICharacterRepository
    {
        bool IsValidFileName(string fileName);
        Task<string> GetCharacterFileContentAsync(string fileName);
        Task<IEnumerable<CharacterUpdateRequest>> GetCharacterFileListAsync();
        Task<string> SaveCharacterAsync(CharacterCreationRequest request);
        Task UpdateCharacterAsync(string fileName, CharacterUpdateRequest request);
        Task DeleteCharacterAsync(string fileName);
    }
}

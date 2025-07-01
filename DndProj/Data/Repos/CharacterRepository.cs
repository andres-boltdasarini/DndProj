using System.Text.Json;
using DndProj.Contracts.Models.Character;

namespace DndProj.Data.Repos
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly IWebHostEnvironment _env;

        public CharacterRepository(IWebHostEnvironment env)
        {
            _env = env;
        }

        public bool IsValidFileName(string fileName)
        {
            return fileName.StartsWith("character_") &&
                   fileName.EndsWith(".json") &&
                   !fileName.Contains("..");
        }

        public async Task<string> GetCharacterFileContentAsync(string fileName)
        {
            string filePath = Path.Combine(_env.ContentRootPath, fileName);
            return await System.IO.File.ReadAllTextAsync(filePath);
        }

        public async Task<string> SaveCharacterAsync(AddCharacterRequest request)
        {
            string fileName = $"character_{DateTime.Now:yyyyMMddHHmmss}.json";
            string filePath = Path.Combine(_env.ContentRootPath, fileName);

            var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(request, jsonOptions);

            await System.IO.File.WriteAllTextAsync(filePath, json);

            return fileName;
        }
    }
}

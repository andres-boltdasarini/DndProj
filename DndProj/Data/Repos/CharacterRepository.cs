﻿using System.Text.Json;
using DndProj.Contracts.Models.Character;

namespace DndProj.Data.Repos
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly IWebHostEnvironment _env;
        private const string DataFolder = "Data";
        private const string ListFolder = "List";

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
            string listFolderPath = Path.Combine(_env.ContentRootPath, DataFolder, ListFolder);
            string filePath = Path.Combine(listFolderPath, fileName);
            return await System.IO.File.ReadAllTextAsync(filePath);
        }

        public async Task<string> SaveCharacterAsync(CharacterCreationRequest request)
        {
            string listFolderPath = Path.Combine(_env.ContentRootPath, DataFolder, ListFolder);
            Directory.CreateDirectory(listFolderPath);

            string fileName = $"character_{DateTime.Now:yyyyMMddHHmmss}.json";
            string filePath = Path.Combine(listFolderPath, fileName);

            var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(request, jsonOptions);

            await System.IO.File.WriteAllTextAsync(filePath, json);

            return fileName;
        }

         public async Task UpdateCharacterAsync(string fileName, CharacterUpdateRequest request)
        {
            string listFolderPath = Path.Combine(_env.ContentRootPath, DataFolder, ListFolder);
            string filePath = Path.Combine(listFolderPath, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                throw new FileNotFoundException("Character file not found", fileName);
            }

            var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(request, jsonOptions);

            await System.IO.File.WriteAllTextAsync(filePath, json);
        }

        public async Task DeleteCharacterAsync(string fileName)
        {
            string listFolderPath = Path.Combine(_env.ContentRootPath, DataFolder, ListFolder);
            string filePath = Path.Combine(listFolderPath, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                throw new FileNotFoundException("Character file not found", fileName);
            }

            System.IO.File.Delete(filePath);
            await Task.CompletedTask; // Для асинхронности, хотя операция синхронная
        }
    }
}

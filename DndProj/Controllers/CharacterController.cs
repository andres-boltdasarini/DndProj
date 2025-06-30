using System.Text.Json;
using DndProj.Contracts.Models.Character;
using Microsoft.AspNetCore.Mvc;


namespace HomeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public CharacterController(
            IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        [Route("{fileName}")]
        public IActionResult GetCharacterFile(string fileName)
        {
            if (!fileName.StartsWith("character_") ||
                !fileName.EndsWith(".json") ||
                fileName.Contains(".."))
            {
                return BadRequest("Некорректное имя файла");
            }

            string filePath = Path.Combine(_env.ContentRootPath, fileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound("Файл не найден");

            try
            {
                string jsonContent = System.IO.File.ReadAllText(filePath);
                return Content(jsonContent, "application/json");
            }
            catch
            {
                return StatusCode(500, "Ошибка чтения файла");
            }
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] AddCharacterRequest request)
        {
            string fileName = $"character_{DateTime.Now:yyyyMMddHHmmss}.json";
            string rootPath = _env.ContentRootPath;
            string filePath = Path.Combine(rootPath, fileName);

            var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(request, jsonOptions);

            System.IO.File.WriteAllText(filePath, json);

            return StatusCode(200, $"{fileName} добавлен!");
        }
    }
}
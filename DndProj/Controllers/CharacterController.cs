using DndProj.Contracts.Models.Character;
using DndProj.Data.Repos;
using Microsoft.AspNetCore.Mvc;


namespace HomeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterController(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        [HttpGet]
        [Route("{fileName}")]
        public async Task<IActionResult> GetCharacterFile(string fileName)
        {
            if (!_characterRepository.IsValidFileName(fileName))
            {
                return BadRequest("Некорректное имя файла");
            }

            try
            {
                string jsonContent = await _characterRepository.GetCharacterFileContentAsync(fileName);
                return Content(jsonContent, "application/json");
            }
            catch (FileNotFoundException)
            {
                return NotFound("Файл не найден");
            }
            catch
            {
                return StatusCode(500, "Ошибка чтения файла");
            }
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] AddCharacterRequest request)
        {
            string fileName = await _characterRepository.SaveCharacterAsync(request);
            return Ok($"{fileName} добавлен!");
        }
    }
}
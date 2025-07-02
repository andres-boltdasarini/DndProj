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
        public async Task<IActionResult> Add([FromBody] CharacterCreationRequest request)
        {
            string fileName = await _characterRepository.SaveCharacterAsync(request);
            return Ok($"{fileName} добавлен!");
        }

        [HttpPut]
        [Route("Update/{fileName}")]
        public async Task<IActionResult> Update(string fileName, [FromBody] CharacterUpdateRequest request)
        {
            if (!_characterRepository.IsValidFileName(fileName))
            {
                return BadRequest("Некорректное имя файла");
            }

            try
            {
                await _characterRepository.UpdateCharacterAsync(fileName, request);
                return Ok($"Персонаж {fileName} успешно обновлён");
            }
            catch (FileNotFoundException)
            {
                return NotFound("Файл не найден");
            }
            catch
            {
                return StatusCode(500, "Ошибка при обновлении персонажа");
            }
        }

        [HttpDelete]
        [Route("Delete/{fileName}")]
        public async Task<IActionResult> Delete(string fileName)
        {
            if (!_characterRepository.IsValidFileName(fileName))
            {
                return BadRequest("Некорректное имя файла");
            }

            try
            {
                await _characterRepository.DeleteCharacterAsync(fileName);
                return Ok($"Персонаж {fileName} успешно удалён");
            }
            catch (FileNotFoundException)
            {
                return NotFound("Файл не найден");
            }
            catch
            {
                return StatusCode(500, "Ошибка при удалении персонажа");
            }
        }
    }
}
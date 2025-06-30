using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using AutoMapper;
using HomeApi.Configuration;
using HomeApi.Contracts.Models.Devices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HomeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        //private readonly IOptions<HomeOptions> _options;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public CharacterController(
            //IOptions<HomeOptions> options,
            IMapper mapper,
            IWebHostEnvironment env)
        {
            //_options = options;
            _mapper = mapper;
            _env = env;
        }

        /// <summary>
        /// Просмотр списка файлов устройств
        /// </summary>
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            string rootPath = _env.ContentRootPath;
            var deviceFiles = Directory.GetFiles(rootPath, "device_*.json")
                .Select(Path.GetFileName)
                .ToList();

            if (deviceFiles.Count == 0)
                return StatusCode(200, "Устройства отсутствуют");

            return Ok(deviceFiles);
        }

        /// <summary>
        /// Получение содержимого файла устройства
        /// </summary>
        [HttpGet]
        [Route("{fileName}")]
        public IActionResult GetDeviceFile(string fileName)
        {
            if (!fileName.StartsWith("device_") ||
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

        /// <summary>
        /// Получение всех устройств (десериализованные объекты)
        /// </summary>
        [HttpGet]
        [Route("devices")]
        public IActionResult GetDevices()
        {
            string rootPath = _env.ContentRootPath;
            var deviceFiles = Directory.GetFiles(rootPath, "device_*.json");
            var devices = new List<AddDeviceRequest>();

            foreach (var filePath in deviceFiles)
            {
                try
                {
                    string jsonContent = System.IO.File.ReadAllText(filePath);
                    var device = JsonSerializer.Deserialize<AddDeviceRequest>(jsonContent);
                    devices.Add(device);
                }
                catch
                {
                    // Пропускаем битые файлы
                }
            }

            if (devices.Count == 0)
                return StatusCode(200, "Устройства отсутствуют");

            return Ok(devices);
        }

        /// <summary>
        /// Добавление нового устройства
        /// </summary>
        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] AddDeviceRequest request)
        {
            string fileName = $"device_{DateTime.Now:yyyyMMddHHmmss}.json";
            string rootPath = _env.ContentRootPath;
            string filePath = Path.Combine(rootPath, fileName);

            var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(request, jsonOptions);

            System.IO.File.WriteAllText(filePath, json);

            return StatusCode(200, $"Устройство {request.Name} добавлено! Файл: {fileName}");
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using System.Collections.Generic;
using Newtonsoft.Json; // Для сериализации в JSON

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody] List<DataItem> dataItems)
        {
            var fileName = $"{Guid.NewGuid()}.json";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/json", fileName);

            Directory.CreateDirectory("json");

            var json = JsonConvert.SerializeObject(dataItems, Formatting.Indented);

            System.IO.File.WriteAllText(filePath, json);

            return Ok($"Data saved to {filePath}");
        }
    }
}

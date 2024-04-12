using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody] Message message)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/messages", $"{Guid.NewGuid()}.txt");

            Directory.CreateDirectory("messages");

            System.IO.File.WriteAllText(filePath, message.Text);

            return Ok($"Message saved to {filePath}");
        }
    }
}

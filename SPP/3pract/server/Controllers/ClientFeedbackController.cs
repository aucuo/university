using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsFeedbacksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientsFeedbacksController(ApplicationDbContext context)
        {
            _context = context;
        }
        public class SqlQueryRequest
        {
            public string? Query { get; set; }
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _context.ClientFeedback.ToListAsync();
            return Ok(clients); // Возвращает статус 200 OK с данными клиентов в формате JSON
        }
    }
}

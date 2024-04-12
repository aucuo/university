using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public class SqlQueryRequest
        {
            public string Query { get; set; }
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllClients()
        {
            var clientsFeedbacks = await _context.Clients.ToListAsync();
            return Ok(clientsFeedbacks); // Возвращает статус 200 OK с данными клиентов в формате JSON
        }
        [HttpPost("Query")]
        public async Task<IActionResult> ExecuteQuery([FromBody] SqlQueryRequest request)
        {

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = request.Query;
                _context.Database.OpenConnection();

                using (var result = await command.ExecuteReaderAsync())
                {
                    var entities = new List<Dictionary<string, object>>();
                    while (await result.ReadAsync())
                    {
                        var entity = new Dictionary<string, object>();
                        for (var i = 0; i < result.FieldCount; i++)
                        {
                            entity.Add(result.GetName(i), result.GetValue(i));
                        }
                        entities.Add(entity);
                    }
                    return Ok(entities);
                }
            }
        }
    }
}

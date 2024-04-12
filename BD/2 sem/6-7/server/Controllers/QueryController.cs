using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace server.Controllers
{
    public class SqlQueryRequest
    {
        public string Query { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class QueryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QueryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
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

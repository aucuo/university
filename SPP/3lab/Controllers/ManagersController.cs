using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _3lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ManagersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Получение списка всех менеджеров
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manager>>> GetManagers()
        {
            return await _context.Managers.ToListAsync();
        }

        // Добавление нового менеджера
        [HttpPost]
        public async Task<ActionResult<Manager>> PostManager(Manager manager)
        {
            _context.Managers.Add(manager);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetManager), new { id = manager.ManagerID }, manager);
        }

        // Обновление данных менеджера
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManager(int id, Manager manager)
        {
            if (id != manager.ManagerID)
            {
                return BadRequest();
            }

            _context.Entry(manager).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Удаление менеджера
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManager(int id)
        {
            var manager = await _context.Managers.FindAsync(id);
            if (manager == null)
            {
                return NotFound();
            }

            _context.Managers.Remove(manager);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Получение менеджера по ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Manager>> GetManager(int id)
        {
            var manager = await _context.Managers.FindAsync(id);

            if (manager == null)
            {
                return NotFound();
            }

            return manager;
        }
    }
}

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesContext _context;

        public MoviesController(MoviesContext context)
        {
            _context = context;
        }

        [HttpGet("popular")]
        public async Task<IActionResult> GetPopularMovies()
        {
            // Логика получения популярных фильмов
            return Ok(await _context.Movies.ToListAsync());
        }

        // Другие методы API...
    }
}

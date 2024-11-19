using lab3.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace lab3.Pages
{
    public class IndexModel : PageModel
    {
        public PassengerShip NewShip { get; set; } = new PassengerShip();
        public List<PassengerShip> Ships { get; set; } = new List<PassengerShip>();
        public string NewCabin { get; set; }

        public void OnGet()
        {
            // Загрузка начальных данных, если нужно
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Ships.Add(NewShip);
                NewShip = new PassengerShip();  // Сброс формы после добавления
            }
            return Page();
        }

        public void EditShip(PassengerShip ship)
        {
            // Логика редактирования
        }

        public void DeleteShip(PassengerShip ship)
        {
            Ships.Remove(ship);
        }
    }
}

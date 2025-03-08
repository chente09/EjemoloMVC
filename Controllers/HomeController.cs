using Microsoft.AspNetCore.Mvc;
using EjemoloMVC.Services;
using System.Threading.Tasks;

namespace EjemoloMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly DogService _dogService;

        public HomeController(DogService dogService)
        {
            _dogService = dogService;
        }

        // Mostrar la lista de razas
        public async Task<IActionResult> Index(int page = 1, int limit = 10)
        {
            var breeds = await _dogService.GetBreedsAsync(page, limit);
            ViewBag.CurrentPage = page;
            ViewBag.Limit = limit;
            ViewBag.TotalPages = 10; 
            return View(breeds);
        }

        // Mostrar detalles de una raza específica
        public async Task<IActionResult> Details(string id)
        {
            var breed = await _dogService.GetBreedByIdAsync(id);
            if (breed == null || string.IsNullOrEmpty(breed.Name))
            {
                return NotFound();
            }
            return View(breed);
        }
    }
}

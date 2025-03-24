using Microsoft.AspNetCore.Mvc;
using Proyecto.Data;  
using proyecto.Models;  

namespace Proyecto.Controllers  
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Equipos = _context.Equipos.ToList();  

            return View(Equipos);  
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}

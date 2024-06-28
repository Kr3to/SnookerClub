using Microsoft.AspNetCore.Mvc;
using Laboratorium3_App.Models;
using System.Linq;
using Data;

namespace Laboratorium3_App.Controllers
{
    public class HallOfFameController : Controller
    {
        private readonly AppDbContext _context;

        public HallOfFameController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var players = _context.HallOfFame.ToList();
            return View(players);
        }

        public IActionResult Details(int id)
        {
            var player = _context.HallOfFame.FirstOrDefault(h => h.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }
    }
}

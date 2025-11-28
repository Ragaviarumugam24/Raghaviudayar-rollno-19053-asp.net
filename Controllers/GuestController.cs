using Microsoft.AspNetCore.Mvc;
using SimpleHotelApp.Models;
using SimpleHotelApp.Services;

namespace SimpleHotelApp.Controllers
{
    public class GuestController : Controller
    {
        private readonly GuestService _guestService;
        public GuestController(GuestService guestService) => _guestService = guestService;

        public IActionResult Index() => View(_guestService.GetAll());
        public IActionResult Create() => View();
        [HttpPost] public IActionResult Create(Guest guest) { _guestService.Add(guest); return RedirectToAction("Index"); }
    }
}

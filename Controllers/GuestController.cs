using Microsoft.AspNetCore.Mvc;
using HotelApp.Models;
using HotelApp.Services;

namespace HotelApp.Controllers
{
    public class GuestController : Controller
    {
        private readonly GuestService _guestService;

        public GuestController(GuestService guestService)
        {
            _guestService = guestService;
        }

        public IActionResult Index()
        {
            return View(_guestService.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Guest guest)
        {
            _guestService.Add(guest);
            return RedirectToAction("Index");
        }
    }
}

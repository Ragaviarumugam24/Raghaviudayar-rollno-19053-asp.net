using Microsoft.AspNetCore.Mvc;
using HotelApp.Models;
using HotelApp.Services;

namespace HotelApp.Controllers
{
    public class RoomController : Controller
    {
        private readonly RoomService _roomService;

        public RoomController(RoomService roomService)
        {
            _roomService = roomService;
        }

        // =======================
        // LIST + SEARCH + FILTER
        // =======================
        public IActionResult Index(string searchString, string typeFilter)
        {
            var rooms = _roomService.GetAll();

            // Search by room number
            if (!string.IsNullOrEmpty(searchString))
            {
                rooms = rooms
                    .Where(r => r.Number != null && r.Number.Contains(searchString))
                    .ToList();
            }

            // Filter by room type
            if (!string.IsNullOrEmpty(typeFilter))
            {
                rooms = rooms
                    .Where(r => r.Type != null && 
                                r.Type.Equals(typeFilter, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // For dropdowns and filters
            ViewBag.Types = _roomService
                .GetAll()
                .Where(r => r.Type != null)
                .Select(r => r.Type)
                .Distinct()
                .ToList();

            ViewBag.SearchString = searchString;
            ViewBag.TypeFilter = typeFilter;

            return View(rooms);
        }

        // =======================
        // CREATE
        // =======================
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Room room)
        {
            if (!ModelState.IsValid)
                return View(room);

            _roomService.Add(room);
            return RedirectToAction("Index");
        }

        // =======================
        // EDIT
        // =======================
        public IActionResult Edit(int id)
        {
            var room = _roomService.Get(id);
            if (room == null) return NotFound();

            return View(room);
        }

        [HttpPost]
        public IActionResult Edit(Room room)
        {
            if (!ModelState.IsValid)
                return View(room);

            _roomService.Update(room);
            return RedirectToAction("Index");
        }

        // =======================
        // DELETE
        // =======================
        public IActionResult Delete(int id)
        {
            _roomService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}


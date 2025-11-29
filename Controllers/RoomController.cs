using Microsoft.AspNetCore.Mvc;
using HotelApp.Models;
using HotelApp.Services;

using HotelApp.Services.Controllers
{
    public class RoomController : Controller
    {
        private readonly RoomService _roomService;
        public RoomController(RoomService roomService) => _roomService = roomService;

        public IActionResult Index(string searchString, string typeFilter)
{
    var rooms = _roomService.GetAll();

    if (!string.IsNullOrEmpty(searchString))
    {
        rooms = rooms.Where(r => r.Number.Contains(searchString)).ToList();
    }

    if (!string.IsNullOrEmpty(typeFilter))
    {
        rooms = rooms.Where(r => r.Type.Equals(typeFilter, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    ViewBag.Types = _roomService.GetAll().Select(r => r.Type).Distinct().ToList();
    ViewBag.SearchString = searchString;
    ViewBag.TypeFilter = typeFilter;

    return View(rooms);
}

        public IActionResult Create() => View();
        [HttpPost] public IActionResult Create(Room room) { _roomService.Add(room); return RedirectToAction("Index"); }
        public IActionResult Edit(int id) => View(_roomService.Get(id));
        [HttpPost] public IActionResult Edit(Room room) { _roomService.Update(room); return RedirectToAction("Index"); }
        public IActionResult Delete(int id) { _roomService.Delete(id); return RedirectToAction("Index"); }
    }
}

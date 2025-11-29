using Microsoft.AspNetCore.Mvc;
using SimpleHotelApp.Models;
using SimpleHotelApp.Services;

using HotelApp.ServicesControllers;
{
    public class BookingController : Controller
    {
        private readonly BookingService _bookingService;
        private readonly RoomService _roomService;
        private readonly GuestService _guestService;

        public BookingController(BookingService bookingService, RoomService roomService, GuestService guestService)
        {
            _bookingService = bookingService;
            _roomService = roomService;
            _guestService = guestService;
        }

        public IActionResult Index() => View(_bookingService.GetAll());

        public IActionResult Create()
        {
            ViewBag.Rooms = _roomService.GetAll().Where(r => r.IsAvailable).ToList();
            ViewBag.Guests = _guestService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            _bookingService.Add(booking);
            var room = _roomService.Get(booking.RoomId);
            room.IsAvailable = false;
            return RedirectToAction("Index");
        }

        public IActionResult CheckOut(int id)
        {
            var booking = _bookingService.GetAll().First(b => b.Id == id);
            _bookingService.CheckOut(id);
            var room = _roomService.Get(booking.RoomId);
            room.IsAvailable = true;
            return RedirectToAction("Index");
        }
    }
}

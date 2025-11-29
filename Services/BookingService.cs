using HotelApp.Models;

namespace HotelApp.Services
{
    public class BookingService
    {
        private List<Booking> _bookings = new();

        public List<Booking> GetAll() => _bookings;
        public void Add(Booking booking) { booking.Id = _bookings.Count + 1; _bookings.Add(booking); }
        public void CheckOut(int id)
        {
            var b = _bookings.FirstOrDefault(b => b.Id == id);
            if (b != null) b.CheckOut = DateTime.Now;
        }
    }
}

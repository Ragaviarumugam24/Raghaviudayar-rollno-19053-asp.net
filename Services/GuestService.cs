using SimpleHotelApp.Models;

namespace SimpleHotelApp.Services
{
    public class GuestService
    {
        private List<Guest> _guests = new();
        public List<Guest> GetAll() => _guests;
        public Guest Get(int id) => _guests.FirstOrDefault(g => g.Id == id);
        public void Add(Guest guest) { guest.Id = _guests.Count + 1; _guests.Add(guest); }
    }
}

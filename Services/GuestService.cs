using HotelApp.Models;

namespace HotelApp.Services
{
    public class GuestService
    {
        private readonly List<Guest> _guests = new();

        // Get all guests
        public List<Guest> GetAll() => _guests;

        // Get a single guest by ID
        public Guest? Get(int id) => _guests.FirstOrDefault(g => g.Id == id);

        // Add new guest with automatically generated unique ID
        public void Add(Guest guest)
        {
            guest.Id = _guests.Count > 0 ? _guests.Max(g => g.Id) + 1 : 1;
            _guests.Add(guest);
        }
    }
}


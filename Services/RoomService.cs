using SimpleHotelApp.Models;

namespace SimpleHotelApp.Services
{
    public class RoomService
    {
        private List<Room> _rooms = new()
        {
            new Room { Id = 1, Number = "101", Type = "Single" },
            new Room { Id = 2, Number = "102", Type = "Double" },
            new Room { Id = 3, Number = "103", Type = "Suite" }
        };

        public List<Room> GetAll() => _rooms;
        public Room Get(int id) => _rooms.FirstOrDefault(r => r.Id == id);
        public void Add(Room room) { room.Id = _rooms.Max(r => r.Id) + 1; _rooms.Add(room); }
        public void Update(Room room)
        {
            var existing = _rooms.First(r => r.Id == room.Id);
            existing.Number = room.Number; existing.Type = room.Type; existing.IsAvailable = room.IsAvailable;
        }
        public void Delete(int id) => _rooms.RemoveAll(r => r.Id == id);
    }
}

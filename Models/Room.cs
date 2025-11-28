namespace SimpleHotelApp.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}

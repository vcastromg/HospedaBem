namespace DTOs;

public class RegisterRoomDTO
{
    public ushort Number { get; set; }
    public ushort GuestsCapacity { get; set; }
    public bool IsAvailable { get; set; }
    public double Price { get; set; }
    public string HotelId { get; set; }
}
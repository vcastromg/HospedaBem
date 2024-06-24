namespace DTOs;

public class RegisterRoomDTO
{
    public ushort Number { get; set; }
    public ushort GuestsCapacity { get; set; }
    public bool IsAvailable { get; set; }
    public decimal Price { get; set; }
    public string HotelId { get; set; }
}
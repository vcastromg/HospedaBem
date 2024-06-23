namespace DTOs;

public class CreateBookingDTO
{
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public string? Comment { get; set; }
    public string UserId { get; set; }
    public string RoomId { get; set; }
}
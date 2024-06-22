namespace DTOs;

public class CreateReviewDTO
{
    public string? Pros { get; set; }
    public string? Cons { get; set; }
    public ushort Rate { get; set; }
    public string UserId { get; set; }
    public string BookingId { get; set; }
}
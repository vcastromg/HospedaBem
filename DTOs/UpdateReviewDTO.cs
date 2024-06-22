namespace DTOs;

public class UpdateReviewDTO
{
    public int Id { get; set; }
    public string? Pros { get; set; }
    public string? Cons { get; set; }
    public ushort Rate { get; set; }
}
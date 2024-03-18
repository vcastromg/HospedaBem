namespace Domain.Entities;

public class Review
{
    public string Pros { get; set; }
    public string Cons { get; set; }
    public ushort Rate { get; set; }
    
    public virtual Booking Booking { get; set; }
}
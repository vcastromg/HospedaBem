using Domain.Entities;

namespace Domain;

public class Review: BaseEntity
{
    public string Pros { get; set; }
    public string Cons { get; set; }
    public ushort Rate { get; set; }
    
    public virtual Booking Booking { get; set; }
    public virtual AppUser User { get; set; }
}
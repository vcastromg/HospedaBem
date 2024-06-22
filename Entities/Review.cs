using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain;

public class Review: BaseEntity
{
    public string Pros { get; set; }
    public string Cons { get; set; }
    public ushort Rate { get; set; }
    
    public virtual Booking Booking { get; set; }
    public virtual IdentityUser User { get; set; }

    public Review()
    {
    }

    public Review(string pros, string cons, ushort rate, Booking booking, IdentityUser user)
    {
        Pros = pros;
        Cons = cons;
        Rate = rate;
        Booking = booking;
        User = user;
    }
}
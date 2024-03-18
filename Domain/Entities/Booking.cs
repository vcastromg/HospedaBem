using System.Globalization;

namespace Domain.Entities;

public class Booking
{
    public Calendar CheckIn { get; set; }
    public Calendar CheckOut { get; set; }
    public string Comment { get; set; }

    // TODO: How to reference users?
    // public virtual ApplicationUser User;
    public virtual Room Room { get; set; }
}
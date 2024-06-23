using Domain.Entities;

namespace Domain;

public class Booking: BaseEntity
{
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public string? Comment { get; set; }

    public virtual AppUser User { get; set; }
    public virtual Room Room { get; set; }

    public Booking() { }

    public Booking(DateTime checkIn, DateTime checkOut, AppUser user, Room room)
    {
        CheckIn = checkIn;
        CheckOut = checkOut;
        User = user;
        Room = room;
    }
}
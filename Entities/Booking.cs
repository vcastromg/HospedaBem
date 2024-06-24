using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain;

public class Booking: BaseEntity
{
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public string? Comment { get; set; }

    public virtual IdentityUser User { get; set; }
    public virtual Room Room { get; set; }
}
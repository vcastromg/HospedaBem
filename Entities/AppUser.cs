using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain;

public class AppUser : IdentityUser
{
    public virtual ICollection<Hotel>? Hotels { get; set; }
}
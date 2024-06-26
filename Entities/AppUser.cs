using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain;

public class AppUser : IdentityUser
{
    public virtual Hotel[]? Hotels { get; set; }
}
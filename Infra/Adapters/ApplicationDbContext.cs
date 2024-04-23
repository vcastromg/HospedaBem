using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<AppUser> Users { get; set; }
}
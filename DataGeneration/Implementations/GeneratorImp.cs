using Bogus;
using Domain.Entities;
using Infra;

namespace DataGeneration.Implementations;

public class GeneratorImp : Generator
{
    private readonly ApplicationDbContext _applicationDbContext;
    public GeneratorImp(ApplicationDbContext applicationDbContext) : base()
    {
        _applicationDbContext = applicationDbContext;
    }

    public void GenerateHotels(int hotelQuantity)
    {
        var roomFaker = new Faker<Room>()
            .RuleFor(r => r.GuestsCapacity, f => f.Random.Int(1, 4))
            .RuleFor(r => r.Type, f => f.PickRandom("Single", "Double", "Suite"))
            .RuleFor(r => r.Price, f => f.Finance.Amount(50, 500));

        var hotelFaker = new Faker<Hotel>()
            .RuleFor(e => e.Name, f => f.Address.City() + " Hotel")
            .RuleFor(e => e.CoverImageUrl, f => f.Image.PicsumUrl())
            .RuleFor(e => e.CreatedAt, DateTime.Now)
            .RuleFor(e => e.UpdatedAt, DateTime.Now)
            .RuleFor(e => e.Address, f => new Address
            {
                AddressLine = f.Address.StreetAddress(),
                PostalCode = f.Address.ZipCode(),
                Longitude = f.Address.Longitude(),
                Latitude = f.Address.Latitude(),
                City = f.Address.City()
            })
            .RuleFor(e => e.Rooms, f => roomFaker.Generate(f.Random.Int(2, 10)));
        hotelFaker.Locale = "pt_BR";
        
        var hotels = hotelFaker.Generate(hotelQuantity);
        _applicationDbContext.Hotels.AddRange(hotels);
        _applicationDbContext.SaveChanges();
    }
}
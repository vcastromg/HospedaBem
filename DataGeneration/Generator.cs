namespace DataGeneration;
using Domain.Entities;

public interface Generator
{
    Task GenerateHotels(int hotelQuantity);
    List<Hotel> GenerateHotelsList(int hotelQuantity);
}
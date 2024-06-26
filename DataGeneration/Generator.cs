namespace DataGeneration;
using Domain.Entities;

public interface Generator
{
    void GenerateHotels(int hotelQuantity);
    List<Hotel> GenerateHotelsList(int hotelQuantity);
}
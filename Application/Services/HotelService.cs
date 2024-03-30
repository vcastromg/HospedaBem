namespace Application.Services;

public interface HotelService
{
    ICollection<string> GetLastRegisteredHotelNames();
}
using Application.Repositories;
using Domain.Entities;

namespace Application.Services.Implementations;

public class HotelServiceImp : HotelService
{
    private readonly HotelRepository _hotelRepository;

    public HotelServiceImp(HotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public IEnumerable<Hotel> GetAllHotels()
    {
        return _hotelRepository.GetAll();
    }

    public IEnumerable<Hotel>? GetRandomHotels(int quantity)
    {
        if (quantity == 0)
        {
            return [];
        }

        var hotelsCount = _hotelRepository.Count();

        if (hotelsCount < quantity)
        {
            return null;
        }
        
        var uniqueRandomIntegers = new HashSet<int>();
        Random rand = new Random();
        while (uniqueRandomIntegers.Count < quantity)
        {
            int randomNumber = rand.Next(1, hotelsCount);
            uniqueRandomIntegers.Add(randomNumber);
        }

        var hotels = new List<Hotel>();
        foreach (var randomIndex in uniqueRandomIntegers)
        {
            var hotel = _hotelRepository.GetHotelByPosition(randomIndex);
            hotels.Add(hotel);
        }

        return hotels;
    }

    public ICollection<string> GetLastRegisteredHotelNames()
    {
        return _hotelRepository.GetLastRegisteredHotelNames();
    }

    public void RegisterHotel(Hotel hotel)
    {
        var newHotel = new Hotel(hotel.Name, new List<Room>());
        _hotelRepository.Add(newHotel);
    }

    public bool RemoveHotelById(long hotelId)
    {
        var hotel = _hotelRepository.GetById(hotelId);

        if(hotel == null)
        {
            return false;
        }

        _hotelRepository.Delete(hotel);
        return true;
    }

    public IEnumerable<Hotel> GetRoomsByHotelId(long hotelId)
    {
        throw new NotImplementedException();
    }

    public ICollection<Hotel> GetHotelsByRate(string rate)
    {
        return _hotelRepository.GetHotelsByRate(double.Parse(rate));
    }

    public ICollection<Room> GetAvailableRoomsInHotel(string hotelName)
    {
        return _hotelRepository.GetRoomsAvailableInHotel(hotelName);
    }

    public Hotel? GetHotelById(long id)
    {
        return _hotelRepository.GetHotelByIdForPage(id);
    }
}
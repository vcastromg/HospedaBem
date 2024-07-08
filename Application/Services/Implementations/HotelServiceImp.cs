using Application.Repositories;
using Domain.Entities;
using DTOs;

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

    public Hotel GetHotelById(string id)
    {
        var hotel = _hotelRepository.GetById(long.Parse(id));
        if (hotel == null)
        {
            throw new Exception("Hotel not found");
        }

        return hotel;
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

    public void RegisterHotel(CreateHotelDTO dto)
    {
        var newAddress = new Address()
        {
            PostalCode = dto.PostalCode ?? "00000000",
            City = dto.City ?? "Belo Horizonte",
            AddressLine = dto.AddressLine ?? "Rua Teste01, 100",
            Latitude = dto.Latitude ?? 0.0,
            Longitude = dto.Longitude ?? 0.0
        };

        var newHotel = new Hotel()
        {
            Name = dto.Name,
            Rate = dto.Rate,
            CoverImageUrl = dto.CoverImageUrl,
            Address = newAddress,
            Rooms = null
        };
        
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

    public void UpdateHotelCoverImage(long hotelId,  string imageUrl)
    {
        var hotel = _hotelRepository.GetById(hotelId);
        if (hotel == null)
        {
            throw new Exception("Hotel not found");
        }

        hotel.CoverImageUrl = imageUrl;
        _hotelRepository.Update(hotel);
    }

    public ICollection<Hotel> GetHotelsByRate(string rate)
    {
        return _hotelRepository.GetHotelsByRate(double.Parse(rate));
    }

    public ICollection<Room> GetAvailableRoomsInHotel(string hotelId, DateTime? checkIn, DateTime? checkOut)
    {
        return _hotelRepository.GetRoomsAvailableInHotel(long.Parse(hotelId), checkIn, checkOut);
    }

    public Hotel? GetHotelById(long id)
    {
        return _hotelRepository.GetHotelByIdForPage(id);
    }

    public IEnumerable<Hotel> Search(HotelSearchDto dto)
    {
        return _hotelRepository.Search(dto);
    }
}
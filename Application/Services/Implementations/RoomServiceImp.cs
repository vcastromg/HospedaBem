using Application.Repositories;
using Domain.Entities;
using DTOs;

namespace Application.Services.Implementations;

public class RoomServiceImp : RoomService
{
    private readonly RoomRepository _roomRepository;
    private readonly HotelService _hotelService;

    public RoomServiceImp(RoomRepository roomRepository, HotelService hotelService)
    {
        _roomRepository = roomRepository;
        _hotelService = hotelService;
    }

    public IEnumerable<Room> Search(RoomSearchDTO dto)
    {
        var query = _roomRepository.Query();
        if (dto.MinimumRate != null)
        {
            query = query.Where(q => q.Hotel.Rate >= dto.MinimumRate);
        }

        if (dto.MinimumPrice != null)
        {
            query = query.Where(q => q.Price >= dto.MinimumPrice);
        }

        if (dto.MaximumPrice != null)
        {
            query = query.Where(q => q.Price <= dto.MaximumPrice);
        }

        if (dto.CityName != null)
        {
            query = query.Where(q => q.Hotel.Address.City.Contains(dto.CityName));
        }

        return query.ToList();
    }

    public Room RegisterRoom(RegisterRoomDTO dto)
    {
        //find hotel by id
        var newRoom = new Room()
        {
            Number = dto.Number,
            GuestsCapacity = dto.GuestsCapacity,
            IsAvailable = dto.IsAvailable,
            Price = dto.Price,
            Hotel = null
        };
        
        _roomRepository.Add(newRoom);

        return newRoom;
    }
}
using Application.Repositories;
using Domain.Entities;

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

    public Room RegisterRoom(RegisterRoomDTO dto)
    {
        var hotel = _hotelService.GetHotelById(dto.HotelId);
        var newRoom = new Room()
        {
            Number = dto.Number,
            GuestsCapacity = dto.GuestsCapacity,
            IsAvailable = dto.IsAvailable,
            Price = dto.Price,
            Hotel = hotel
        };
        
        _roomRepository.Add(newRoom);

        return newRoom;
    }

    public Room FindRoomById(string id)
    {
        var room = _roomRepository.GetById(long.Parse(id));
        if (room == null)
        {
            throw new Exception("Room not found");
        }

        return room;
    }
}
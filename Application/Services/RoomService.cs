using Domain;
using DTOs;

namespace Application.Services;

public interface RoomService
{
    IEnumerable<Room> SearchRooms(RoomSearchDTO search);
}
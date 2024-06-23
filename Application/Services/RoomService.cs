using Domain.Entities;

namespace Application.Services;

public interface RoomService
{
    Room RegisterRoom(RegisterRoomDTO dto);
    Room FindRoomById(string id);
}
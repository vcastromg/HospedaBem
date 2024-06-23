using Domain.Entities;
using DTOs;

namespace Application.Services;

public interface RoomService
{
    Room RegisterRoom(RegisterRoomDTO dto);
    Room FindRoomById(string id);
}
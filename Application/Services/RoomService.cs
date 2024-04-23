using Domain.Entities;
using DTOs;

namespace Application.Services;

public interface RoomService
{
    IEnumerable<Room> Search(RoomSearchDTO dto);
}
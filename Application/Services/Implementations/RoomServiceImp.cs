using Application.Repositories;

namespace Application.Services.Implementations;

public class RoomServiceImp : RoomService
{
    private readonly RoomRepository _roomRepository;

    public RoomServiceImp(RoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }
}
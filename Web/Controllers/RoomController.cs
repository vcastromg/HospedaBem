using Application.Services;
using Domain.Entities;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalArchitecture.Controllers;

[ApiController]
[Route("/api/room")]
public class RoomController : ControllerBase
{
    private readonly RoomService _roomService;

    public RoomController(RoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpPost]
    public IActionResult RegisterRoom(RegisterRoomDTO dto)
    {
        _roomService.RegisterRoom(dto);
        return Created();
    }

    [HttpGet]
    [Route("/api/room/{id}")]
    public IActionResult GetRoomById([FromRoute] string id)
    {
        return Ok(_roomService.FindRoomById(id));
    }
}
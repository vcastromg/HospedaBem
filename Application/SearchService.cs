using Domain.Entities;
using DTOs;

namespace Application;

public interface SearchService
{
    ICollection<Hotel> FindClosestHotels(double latitude, double longitude, Pagination pagination);
}
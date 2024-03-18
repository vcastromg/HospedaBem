using Domain.Entities;
using DTOs;

namespace Application.Implementations;

public class SearchServiceImp : SearchService
{
    public ICollection<Hotel> FindClosestHotels(double latitude, double longitude, Pagination pagination)
    {
        throw new NotImplementedException();
    }
}
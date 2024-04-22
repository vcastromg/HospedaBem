using Domain.Entities;

namespace Infra.Repositories;

public interface HotelRepository: BaseRepository<Hotel>
{
    public ICollection<string> GetLastRegisteredHotelNames();
}
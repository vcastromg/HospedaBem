using Domain.Entities;

namespace Infra.Repositories.Implementations;

public class HotelRepositoryImp : BaseRepositoryImp<Hotel>, HotelRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public HotelRepositoryImp(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
}
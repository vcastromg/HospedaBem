using Application.Repositories;
using Infra;

namespace Domain.Repositories.Implementations;

public class RoomRepositoryImp : BaseRepositoryImp<Room>, RoomRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public RoomRepositoryImp(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
}
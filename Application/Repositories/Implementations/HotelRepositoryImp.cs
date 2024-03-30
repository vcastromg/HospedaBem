using Application.Repositories;
using Domain.Entities;
using Infra;

namespace Domain.Repositories.Implementations;

public class HotelRepositoryImp : BaseRepositoryImp<Hotel>, HotelRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public HotelRepositoryImp(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
}
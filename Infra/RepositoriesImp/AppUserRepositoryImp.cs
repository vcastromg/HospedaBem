using Application.Repositories;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Infra.Repositories.Implementations;

public class AppUserRepositoryImp : BaseRepositoryImp<IdentityUser>, AppUserRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly UserManager<IdentityUser> _userManager;

    public AppUserRepositoryImp(ApplicationDbContext applicationDbContext, UserManager<IdentityUser> userManager) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        _userManager = userManager;
    }

    public IEnumerable<IdentityUser> GetAll()
    {
        return _userManager.Users;
    }
}
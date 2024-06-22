using Domain;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;

public interface AppUserService
{
    public IEnumerable<IdentityUser> GetAll();
    public IdentityUser FindById(string id);
}
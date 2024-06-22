using Domain;
using Microsoft.AspNetCore.Identity;

namespace Application.Repositories;

public interface AppUserRepository : BaseRepository<IdentityUser>
{
    public IEnumerable<IdentityUser> GetAll();

    public IdentityUser FindById(string id);
}
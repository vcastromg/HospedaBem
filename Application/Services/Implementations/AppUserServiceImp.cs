using System.Collections;
using Application.Repositories;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.Implementations;

public class AppUserServiceImp : AppUserService
{
    private readonly AppUserRepository _appUserRepository;

    public AppUserServiceImp(AppUserRepository appUserRepository)
    {
        _appUserRepository = appUserRepository;
    }

    public IEnumerable<IdentityUser> GetAll()
    {
        var users = _appUserRepository.GetAll();
        if (!users.Any())
        {
            throw new Exception("No users to be shown");
        }

        return users;
    }

}
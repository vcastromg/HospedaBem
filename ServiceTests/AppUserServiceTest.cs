using Application.Repositories;
using Application.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace ServiceTests;

public class AppUserServiceTest
{
    [Fact]
    public void GetAll_ShouldReturnUsers_WhenUsersExist()
    {
        var appUserRepositoryMock = new Mock<AppUserRepository>();
        var appUserService = new AppUserServiceImp(appUserRepositoryMock.Object);
        var users = new List<IdentityUser>
        {
            new IdentityUser { Id = "1", UserName = "user1" },
            new IdentityUser { Id = "2", UserName = "user2" }
        };
        
        appUserRepositoryMock.Setup(repo => repo.GetAll())
            .Returns(users);
        
        var result = appUserService.GetAll();
        
        Assert.NotNull(result);
        Assert.Equal(users.Count, result.Count());
    }
    
    [Fact]
    public void GetAll_ShouldThrowException_WhenNoUsersExist()
    {
        var appUserRepositoryMock = new Mock<AppUserRepository>();
        var appUserService = new AppUserServiceImp(appUserRepositoryMock.Object);
        
        appUserRepositoryMock.Setup(repo => repo.GetAll())
            .Returns(new List<IdentityUser>());
        
        Assert.Throws<Exception>(() => appUserService.GetAll());
    }
    
    [Fact]
    public void FindById_ShouldReturnUser_WhenUserExists()
    {
        var userId = "1";
        var appUserRepositoryMock = new Mock<AppUserRepository>();
        var appUserService = new AppUserServiceImp(appUserRepositoryMock.Object);
        var existingUser = new IdentityUser { Id = userId, UserName = "user1" };
        
        appUserRepositoryMock.Setup(repo => repo.FindById(userId))
            .Returns(existingUser);
        
        var result = appUserService.FindById(userId);
        
        Assert.NotNull(result);
        Assert.Equal(existingUser, result);
    }
}
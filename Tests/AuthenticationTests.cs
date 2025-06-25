using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
<<<<<<< HEAD
=======
using LMSApp.Data;
using LMSApp.Services;
using LMSApp.DTOs;
using LMSApp.Models;
>>>>>>> dbe7ede0baee7e9b1efa70f6d723820a0bc80ad7

public class AuthenticationTests
{
    private AppDbContext GetContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new AppDbContext(options);
    }

    [Fact]
    public async Task RegisterAsync_NewUser_ReturnsSuccess()
    {
        using var context = GetContext();
        var service = new AuthService(context);
        var dto = new RegisterUserDto
        {
            FullName = "Test User",
            Email = "test@example.com",
            Password = "password",
            Role = "Student"
        };

        var result = await service.RegisterAsync(dto);
        Assert.Equal("User registered successfully", result);
    }

    [Fact]
    public async Task RegisterAsync_ExistingUser_ReturnsExistsMessage()
    {
        using var context = GetContext();
        context.Users.Add(new User
        {
            FullName = "Existing",
            Email = "exist@example.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("secret"),
            Role = "Student"
        });
        await context.SaveChangesAsync();
        var service = new AuthService(context);
        var dto = new RegisterUserDto
        {
            FullName = "Existing",
            Email = "exist@example.com",
            Password = "secret",
            Role = "Student"
        };

        var result = await service.RegisterAsync(dto);
        Assert.Equal("User already exists", result);
    }

    [Fact]
    public async Task LoginAsync_ValidCredentials_ReturnsSuccess()
    {
        using var context = GetContext();
        context.Users.Add(new User
        {
            FullName = "Login User",
            Email = "login@example.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("mypassword"),
            Role = "Student"
        });
        await context.SaveChangesAsync();
        var service = new AuthService(context);
        var dto = new LoginDto
        {
            Email = "login@example.com",
            Password = "mypassword"
        };

        var result = await service.LoginAsync(dto);
        Assert.Equal("Login successful", result);
    }

    [Fact]
    public async Task LoginAsync_InvalidCredentials_ReturnsNull()
    {
        using var context = GetContext();
        context.Users.Add(new User
        {
            FullName = "Login User",
            Email = "login@example.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("mypassword"),
            Role = "Student"
        });
        await context.SaveChangesAsync();
        var service = new AuthService(context);
        var dto = new LoginDto
        {
            Email = "login@example.com",
            Password = "wrong"
        };

        var result = await service.LoginAsync(dto);
        Assert.Null(result);
    }
}

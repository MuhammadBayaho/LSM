using Microsoft.AspNetCore.Mvc;
using LMSApp.Services;
using LMSApp.DTOs;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserDto dto)
    {
        var result = await _authService.RegisterAsync(dto);
        return Ok(new { message = result });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var result = await _authService.LoginAsync(dto);
        if (result == null) return Unauthorized("Invalid credentials");
        return Ok(new { message = result });
    }
}

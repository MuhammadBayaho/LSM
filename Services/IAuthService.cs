using System.Threading.Tasks;
using LMSApp.DTOs;

namespace LMSApp.Services
{
public interface IAuthService
{
    Task<string> RegisterAsync(RegisterUserDto dto);
    Task<string?> LoginAsync(LoginDto dto);
}
}


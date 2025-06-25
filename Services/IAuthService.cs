using System.Threading.Tasks;
using LMSApp.DTOs;
<<<<<<< HEAD
=======

namespace LMSApp.Services
{
>>>>>>> dbe7ede0baee7e9b1efa70f6d723820a0bc80ad7
public interface IAuthService
{
    Task<string> RegisterAsync(RegisterUserDto dto);
    Task<string?> LoginAsync(LoginDto dto);
}
<<<<<<< HEAD
=======
}

>>>>>>> dbe7ede0baee7e9b1efa70f6d723820a0bc80ad7

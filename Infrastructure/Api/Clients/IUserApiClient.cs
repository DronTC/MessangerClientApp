using MessangerClientApp.Infrastructure.Api.DTOs;

namespace MessangerClientApp.Infrastructure.Api.Clients
{
    public interface IUserApiClient
    {
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> RegisterAsync(CreateUserDTO createUserDto);
        Task<AuthResponseDTO> LoginAsync(LoginUserDTO loginDto);
    }
}

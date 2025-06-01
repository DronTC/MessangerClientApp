using MessangerClientApp.Infrastructure.Api.Clients;
using MessangerClientApp.Infrastructure.Api.DTOs;
using Serilog;

namespace MessangerClientApp.Infrastructure.Api
{
    class UserService
    {
        private readonly IUserApiClient _apiClient;

        public UserService(IUserApiClient apiClient) => _apiClient = apiClient;

        public async Task<UserDTO> GetUserAsync(int id)
        {
            try
            {
                return await _apiClient.GetUserByIdAsync(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to get user");
                throw;
            }
        }
        public async Task<UserDTO> RegisterUserAsync(CreateUserDTO createUserDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(createUserDto.Login))
                    throw new ArgumentException("Login is required");

                return await _apiClient.RegisterAsync(createUserDto);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to register user");
                throw;
            }
        }
    }
}

using MessangerClientApp.Infrastructure.Api.Clients;
using MessangerClientApp.Infrastructure.Api.DTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerClientApp.Infrastructure.Api
{
    class UserService
    {
        private readonly IUserApiClient _apiClient;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserApiClient apiClient, ILogger<UserService> logger)
        {
            _apiClient = apiClient;
            _logger = logger;
        }

        public async Task<UserDTO> GetUserAsync(int id)
        {
            try
            {
                return await _apiClient.GetUserByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get user");
                throw;
            }
        }
        public async Task<UserDTO> RegisterUserAsync(CreateUserDTO createUserDto)
        {
            try
            {
                // Дополнительная валидация перед отправкой
                if (string.IsNullOrWhiteSpace(createUserDto.Login))
                    throw new ArgumentException("Login is required");

                return await _apiClient.RegisterAsync(createUserDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to register user");
                throw;
            }
        }
    }
}

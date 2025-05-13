using MessangerClientApp.Infrastructure.Api.DTOs;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net;
using System.Text.Json;
using System.Text;
using MessangerClientApp.Infrastructure.Api.Endpoints;

namespace MessangerClientApp.Infrastructure.Api.Clients
{
    public class UserApiClient : IUserApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<UserApiClient> _logger;
        private readonly JsonSerializerOptions _serializerOptions;

        public UserApiClient(HttpClient httpClient, ILogger<UserApiClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync(UserEndpoints.GetById(id));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<UserDTO>(content, _serializerOptions);
                }

                await HandleErrorResponse(response);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user by ID");
                throw;
            }
        }

        public async Task<UserDTO> RegisterAsync(CreateUserDTO createUserDto)
        {
            try
            {
                var jsonContent = JsonSerializer.Serialize(createUserDto);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(UserEndpoints.Register, httpContent);

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<UserDTO>(content, _serializerOptions);
                }

                await HandleErrorResponse(response);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error registering user");
                throw;
            }
        }

        public async Task<AuthResponseDTO> LoginAsync(LoginUserDTO loginDto)
        {
            try
            {
                var jsonContent = JsonSerializer.Serialize(loginDto);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(UserEndpoints.Login, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<AuthResponseDTO>(content, _serializerOptions);
                }

                await HandleErrorResponse(response);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login");
                throw;
            }
        }

        private async Task HandleErrorResponse(HttpResponseMessage response)
        {
            var errorContent = await response.Content.ReadAsStringAsync();

            switch (response.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    throw new ArgumentException(errorContent);
                case HttpStatusCode.NotFound:
                    throw new KeyNotFoundException(errorContent);
                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedAccessException(errorContent);
                default:
                    var errorMessage = $"HTTP error: {response.StatusCode} - {errorContent}";
                    _logger.LogError(errorMessage);
                    throw new HttpRequestException(errorMessage);
            }
        }
    }
}

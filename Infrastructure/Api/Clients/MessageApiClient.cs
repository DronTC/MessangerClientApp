using MessangerClientApp.Infrastructure.Api.DTOs.Message;
using MessangerClientApp.Infrastructure.Api.Endpoints;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace MessangerClientApp.Infrastructure.Api.Clients
{
    class MessageApiClient: IMessageApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MessageApiClient> _logger;
        private readonly JsonSerializerOptions _serializerOptions;

        public MessageApiClient(HttpClient httpClient, ILogger<MessageApiClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
        }

        public async Task<MessageDTO> GetMessageByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync(MessageEndpoints.GetById(id));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<MessageDTO>(content, _serializerOptions);
                }

                await HandleErrorResponse(response);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting message by ID: {Id}", id);
                throw;
            }
        }

        public async Task<MessageDTO> CreateMessageAsync(CreateMessageDTO createMessageDto)
        {
            try
            {
                var jsonContent = JsonSerializer.Serialize(createMessageDto);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(MessageEndpoints.Create, httpContent);

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<MessageDTO>(content, _serializerOptions);
                }

                await HandleErrorResponse(response);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating message");
                throw;
            }
        }

        public async Task<MessageDTO> UpdateMessageAsync(UpdateMessageDTO updateMessageDto)
        {
            try
            {
                var jsonContent = JsonSerializer.Serialize(updateMessageDto);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(MessageEndpoints.Update, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<MessageDTO>(content, _serializerOptions);
                }

                await HandleErrorResponse(response);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating message: {updateMessageDto.Id}");
                throw;
            }
        }

        public async Task<bool> DeleteMessageAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(MessageEndpoints.Delete(id));

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                await HandleErrorResponse(response);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting message: {id}");
                throw;
            }
        }

        public async Task<IEnumerable<MessageDTO>> GetMessagesByChatAsync(int chatId, int skip = 0, int take = 50)
        {
            try
            {
                var url = $"{MessageEndpoints.GetByChatId(chatId)}?skip={skip}&take={take}";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IEnumerable<MessageDTO>>(content, _serializerOptions);
                }

                await HandleErrorResponse(response);
                return Enumerable.Empty<MessageDTO>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting messages for chat: {chatId}");
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

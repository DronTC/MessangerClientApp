using MessangerClientApp.Infrastructure.Api.DTOs.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerClientApp.Infrastructure.Api.Clients
{
    interface IMessageApiClient
    {
        Task<MessageDTO> GetMessageByIdAsync(int id);
        Task<MessageDTO> CreateMessageAsync(CreateMessageDTO createMessageDTO);
        Task<bool> DeleteMessageAsync(int id);
    }
}

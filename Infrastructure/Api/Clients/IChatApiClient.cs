using MessangerClientApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerClientApp.Infrastructure.Api.Clients
{
    interface IChatApiClient
    {
        Task<List<Message>> GetMessagesAsync(int chatId);
        Task SendMessageAsync(Message message);
    }
}

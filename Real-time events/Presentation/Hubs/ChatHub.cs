using Microsoft.AspNet.SignalR.Infrastructure;
using Microsoft.AspNetCore.SignalR;

namespace Presentation.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IConnectionManager _connectionManager;

        public ChatHub(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public async Task SendMessage(string message)
        {
            // Here you can integrate with the MessageService to store and broadcast the message
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}

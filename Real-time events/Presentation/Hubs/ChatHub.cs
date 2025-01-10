using System.Text;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Real_time_events.Presentation.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IHttpContextAccessor _cookie;
        private readonly IMessageRepository _repository;
        private readonly IDistributedCache _cache;

        public ChatHub(IHttpContextAccessor cookie, IMessageRepository repository, IDistributedCache cache)
        {
            _cache = cache;
            _repository = repository;
            _cookie = cookie;
        }

        public async Task SendMessageToAll(string message)
        {
            var user =await _repository.GetUserDataAsync(_cookie.HttpContext!.Request.Cookies["userId"]!);
            await Clients.All.SendAsync($"{user.FirstName} {user.LastName}:", message);
        }

        public async Task SendMessage(string firstname, string lastname, string message)
        {
            var receiverId = await _repository.GetUserId(firstname, lastname);
            var senderId = Context.UserIdentifier!;
            var user = await _repository.GetUserDataAsync(senderId);    
            await Clients.Users(senderId,receiverId).SendAsync($"{user.FirstName} {user.LastName}", message);
        }

        public override Task OnConnectedAsync()
        {
            var id = _cookie.HttpContext?.Request.Cookies["userId"]!;
            var date = DateTime.UtcNow;
            _cache.SetAsync($"{id}",Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(date)));
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var id = _cookie.HttpContext?.Request.Cookies["userId"]!;
            _cache.RemoveAsync($"{id}");
            return base.OnDisconnectedAsync(exception);
        }
    }
}

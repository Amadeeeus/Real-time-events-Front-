


using Microsoft.AspNetCore.SignalR;

namespace Real_time_events.Infrastructure.Providers;

public class CookieIdProvider:IUserIdProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CookieIdProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetUserId(HubConnectionContext connection)
    {  
        var senderId = connection.GetHttpContext()?.Request.Cookies["UserId"]!;
        return senderId;
    }
}
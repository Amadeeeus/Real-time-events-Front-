using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR.Infrastructure;
using Microsoft.Extensions.Caching.Distributed;

public class RedisConnectionManager : IConnectionManager
{
    private readonly IDistributedCache _redis;

    public RedisConnectionManager(IDistributedCache redis)
    {
        _redis = redis;
    }

    public async Task SetConnectionAsync(string userId, string connectionId)
    {
        await _redis.SetStringAsync($"connection:{userId}", connectionId);
    }

    public async Task<string?> GetConnectionAsync(string userId)
    {
        return await _redis.GetStringAsync($"connection:{userId}");
    }

    public IHubContext GetHubContext<T>() where T : IHub
    {
        throw new NotImplementedException();
    }

    public IHubContext GetHubContext(string hubName)
    {
        throw new NotImplementedException();
    }

    public IHubContext<TClient> GetHubContext<T, TClient>() where T : IHub where TClient : class
    {
        throw new NotImplementedException();
    }

    public IHubContext<TClient> GetHubContext<TClient>(string hubName) where TClient : class
    {
        throw new NotImplementedException();
    }

    public IPersistentConnectionContext GetConnectionContext<T>() where T : PersistentConnection
    {
        throw new NotImplementedException();
    }
}
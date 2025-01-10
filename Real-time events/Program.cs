using System.Dynamic;
using Application.Services;
using Authorization.Infrastructure.DataAccess;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories;
using Microsoft.AspNet.SignalR.Infrastructure;
using Microsoft.AspNetCore.SignalR;
using Real_time_events.Application.Services;
using Real_time_events.Infrastructure.Providers;
using Real_time_events.Presentation.Hubs;
using Real_time_events.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();
builder.Services.AddStackExchangeRedisCache(configuration);
builder.Services.AddDbContext<MessageDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddSingleton<IUserIdProvider, CookieIdProvider>();
builder.Services.AddScoped<IConnectionManager, RedisConnectionManager>();

var app = builder.Build();
app.UseRouting();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<ChatHub>("/chat");
});

app.Run();
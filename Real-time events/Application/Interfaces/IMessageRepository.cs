using Authorization.Core.Entities;
using Domain.Entities;

namespace Infrastructure.Repositories;

public interface IMessageRepository
{
    Task<IEnumerable<Message>> GetMessagesByUserIdAsync(string userId);
    Task AddMessageAsync(Message message);
    Task<string> GetUserId(string firstname, string lastname);
    Task<UserEntity> GetUserDataAsync(string userId);
}
using Domain.Entities;

namespace Infrastructure.Repositories;

public interface IMessageRepository
{
    Task<IEnumerable<Message>> GetMessagesByUserIdAsync(int userId);
    Task AddMessageAsync(Message message);
}
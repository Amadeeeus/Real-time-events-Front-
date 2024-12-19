using Application.DTOs;
using Real_time_events.Domain.Enums;

namespace Application.Services;

public interface IMessageService
{
    Task<IEnumerable<MessageDto>> GetMessagesAsync(int userId);
    Task SendMessageAsync(Guid messageDtoSenderId, Guid messageDtoReceiverId, string messageDtoMessageContent, MessageType messageDtoMessageType);
}
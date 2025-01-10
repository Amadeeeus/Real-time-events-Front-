using Application.DTOs;
using Real_time_events.Domain.Enums;

namespace Application.Services;

public interface IMessageService
{
    Task<IEnumerable<MessageDto>> GetMessagesAsync(string userId);
    Task SendMessageAsync(string messageDtoSenderId, string messageDtoReceiverId, string messageDtoMessageContent, MessageType messageDtoMessageType);
}
using Application.DTOs;
using Application.Services;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNet.SignalR.Infrastructure;
using Real_time_events.Domain.Enums;

namespace Real_time_events.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IConnectionManager _connectionManager;

        public MessageService(IMessageRepository messageRepository, IConnectionManager connectionManager)
        {
            _messageRepository = messageRepository;
            _connectionManager = connectionManager;
        }

        public async Task<IEnumerable<MessageDto>> GetMessagesAsync(int userId)
        {
            var messages = await _messageRepository.GetMessagesByUserIdAsync(userId);
            return messages.Select(m => new MessageDto
            {
                Id = m.Id,
                Content = m.Content,
                UserId = m.UserId,
                SentAt = m.SentAt,
                Type = m.Type
            });
        }

        public Task SendMessageAsync(Guid messageDtoSenderId, Guid messageDtoReceiverId, string messageDtoMessageContent,
            MessageType messageDtoMessageType)
        {
            throw new NotImplementedException();
        }

        public async Task SendMessageAsync(string content, int userId, MessageType type)
        {
            var message = new Message
            {
                Content = content,
                UserId = userId,
                SentAt = DateTime.UtcNow,
                Type = type
            };

            await _messageRepository.AddMessageAsync(message);
        }
    }
}
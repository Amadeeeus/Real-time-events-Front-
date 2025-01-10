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

        public async Task<IEnumerable<MessageDto>> GetMessagesAsync(string userId)
        {
            var messages = await _messageRepository.GetMessagesByUserIdAsync(userId);
            return messages.Select(m => new MessageDto
            {
                Id = m.Id,
                Content = m.Content,
                UserId = m.ReceiverId,
                SentAt = m.SentAt,
                Type = m.Type
            });
        }

        public async Task SendMessageAsync(string senderId, string receiverId, string content, MessageType type)
        {
            var message = new Message
            {
                Content = content,
                SenderId = senderId,
                ReceiverId = receiverId,
                SentAt = DateTime.UtcNow,
                Type = type
            };

            await _messageRepository.AddMessageAsync(message);
        }
    }
}
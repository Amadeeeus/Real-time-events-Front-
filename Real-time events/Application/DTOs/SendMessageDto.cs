using Real_time_events.Domain.Enums;

namespace YourProject.Application.DTOs
{
    public class SendMessageDto
    {
        public string SenderId { get; set; } 
        public string ReceiverId { get; set; }
        public string MessageContent { get; set; } 
        public MessageType MessageType { get; set; }
        public DateTime Timestamp { get; set; } 
    }
}
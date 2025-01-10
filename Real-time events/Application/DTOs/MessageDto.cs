using Real_time_events.Domain.Enums;

namespace Application.DTOs
{
    public class MessageDto
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public MessageType Type { get; set; }
        public DateTime SentAt { get; set; }
    }
}
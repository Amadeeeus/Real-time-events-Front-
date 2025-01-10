using Real_time_events.Domain.Enums;

namespace Domain.Entities
{
    public class Message
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public MessageType Type { get; set; }
        public DateTime SentAt { get; set; }
    }
}
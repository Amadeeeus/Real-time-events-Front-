using Real_time_events.Domain.Enums;

namespace Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public MessageType Type { get; set; }
        public DateTime SentAt { get; set; }
    }
}
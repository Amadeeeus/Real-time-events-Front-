using Real_time_events.Domain.Enums;

namespace Application.DTOs
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public MessageType Type { get; set; }
        public DateTime SentAt { get; set; }
    }
}
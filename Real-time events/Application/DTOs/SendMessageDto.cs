using Real_time_events.Domain.Enums;

namespace YourProject.Application.DTOs
{
    public class SendMessageDto
    {
        public Guid SenderId { get; set; }      // Идентификатор отправителя
        public Guid ReceiverId { get; set; }    // Идентификатор получателя
        public string MessageContent { get; set; } // Содержимое сообщения
        public MessageType MessageType { get; set; }  // Тип сообщения (например, текст, файл, изображение)
        public DateTime Timestamp { get; set; }   // Время отправки сообщения
    }
}
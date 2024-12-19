using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.Services;
using YourProject.Application.DTOs;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly ILogger<MessagesController> _logger;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetMessages(int userId)
        {
            var messages = await _messageService.GetMessagesAsync(userId);
            return Ok(messages);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageDto messageDto)
        {
            if (messageDto == null)
            {
                return BadRequest("Message data is invalid.");
            }

            // Проверка на валидность данных
            if (string.IsNullOrWhiteSpace(messageDto.MessageContent))
            {
                return BadRequest("Message content cannot be empty.");
            }

            try
            {
                // Вызов метода для отправки сообщения
                await _messageService.SendMessageAsync(messageDto.SenderId, messageDto.ReceiverId, messageDto.MessageContent, messageDto.MessageType);

                // Возвращаем статус успеха
                return Ok(new { message = "Message sent successfully" });
            }
            catch (Exception ex)
            {
                // Логируем ошибку и возвращаем ошибку
                _logger.LogError(ex, "Error occurred while sending message.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

    }
}
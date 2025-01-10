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
        public async Task<IActionResult> GetMessages(string userId)
        {
            var messages = await _messageService.GetMessagesAsync(userId);
            return Ok(messages);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageDto messageDto)
        {
                await _messageService.SendMessageAsync(messageDto.SenderId, messageDto.ReceiverId, messageDto.MessageContent, messageDto.MessageType);
                return Ok(new { message = "Message sent successfully" });
        }

    }
}
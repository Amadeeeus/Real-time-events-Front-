using System.Data;
using Domain.Entities;
using FluentValidation;

namespace Real_time_events.Presentation.Validators;

public class MessageValidator:AbstractValidator<Message>
{
   public MessageValidator()
   {
      RuleFor(x=>x.Content).NotEmpty();
      RuleFor(x=>x.ReceiverId).NotEmpty();
      RuleFor(x=>x.SenderId).NotEmpty();
      RuleFor(x=>x.Type).NotEmpty();
      RuleFor(x => x.Content).MinimumLength(5);
      RuleFor(x=>x.Content).MaximumLength(500);
   }
}
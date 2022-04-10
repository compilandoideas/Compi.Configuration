using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi.Configuration.Clean.Service.Core.Application.Commands.SendNotificationError
{
    public class SendNotificationErrorCommandValidator : AbstractValidator<SendNotificationErrorCommand>
    {
        public SendNotificationErrorCommandValidator(ILogger<SendNotificationErrorCommand> logger)
        {

            RuleFor(e => e.From)
              .NotEmpty()
              .NotNull()
              .WithMessage("Debe indicar un remitente en el mensaje.");

            RuleFor(e => e.Subject)
             .NotEmpty()
             .NotNull()
             .WithMessage("Debe indicar un asunto en el mensaje.");


            logger.LogTrace("----- VALIDATOR CREATED - {ClassName}", GetType().Name);

        }
    }
}

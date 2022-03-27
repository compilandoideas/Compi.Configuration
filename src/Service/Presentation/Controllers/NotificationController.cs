using Compi.Configuration.Service.Common;
using Compi.Configuration.Service.Core.Application.Commands.SendNotificationError;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi.Configuration.Service.Presentation.Controllers
{
    public class NotificationController : BaseController
    {

        private readonly IMediator _mediator;

        public NotificationController(IMediator mediator)
        {

            _mediator = mediator ??
                 throw new ArgumentNullException(nameof(mediator));

        }


        public async Task<Result> SendNotificationError(string to, string subject, string from, string date)
        {

            Result result = await _mediator.Send(new SendNotificationErrorCommand(to, subject, from, date));

            return result;

        }

    }
}

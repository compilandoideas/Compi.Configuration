using Compi.Configuration.Service.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Compi.Configuration.Service.Core.Application.Commands.SendNotificationError
{
    public class SendNotificationErrorCommand : IRequest<Result>
    {

        public string To { get; set; }
        public string Subject { get; set; }
        public string From { get; set; }
        public string Date { get; set; }


        public SendNotificationErrorCommand(string to, string subject, string from, string date)
        {
            To = to;
            Subject = subject;
            From = from;
            Date = date;

        }


        internal sealed class SendNotificationErrorCommandHandler : IRequestHandler<SendNotificationErrorCommand, Result>
        {

            private readonly ConnectionString _connectionString;
           // private readonly IViewRenderService _renderService;
           // private readonly IThirtyMinutesShiftOutCheckerService _thirtyMinutesShiftOutCheckerService;

            public SendNotificationErrorCommandHandler(
                ConnectionString connectionString
              //  IViewRenderService viewRenderService,
              //  IThirtyMinutesShiftOutCheckerService thirtyMinutesShiftOutCheckerService
                )
            {

                _connectionString = connectionString ??
                    throw new ArgumentNullException(nameof(connectionString));

                //_renderService = viewRenderService ??
                //    throw new ArgumentNullException(nameof(viewRenderService));

                //_thirtyMinutesShiftOutCheckerService = thirtyMinutesShiftOutCheckerService ??
                //    throw new ArgumentNullException(nameof(thirtyMinutesShiftOutCheckerService));

            }

            public async Task<Result> Handle(SendNotificationErrorCommand request, CancellationToken cancellationToken)
            {

                //Busca personas que no han marcado su salida y crea alertas pendientes de envío.
              //  _thirtyMinutesShiftOutCheckerService.MoveToLog(347);


                //List<AlertLog> alertLogs = new();
                //EmailMessageThirtyMinutesShiftOut notification = new();

              
                //var html = await _renderService.RenderToStringAsync("/Infrastructure/Services/RenderService/Templates/30-minutes-shiftout-email.cshtml", emailMessage);

                
                return await Result.SuccessAsync();
            }
        }



    }

}

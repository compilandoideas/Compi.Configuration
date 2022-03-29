using Compi.Configuration.Service.Common;
using Compi.Configuration.Service.Core.Application.Commands.SendNotificationError;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Compi.Configuration.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMediator _mediator;

        public Worker(ILogger<Worker> logger, IMediator mediator)
        {
            _logger = logger;

            _mediator = mediator ??
                throw new ArgumentNullException(nameof(mediator));

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);


                var to = "";
                var subject = "";
                var from = "";
                var date = "";

                Result result = await _mediator.Send(new SendNotificationErrorCommand(to, subject, from, date));

               
            }
        }
    }
}

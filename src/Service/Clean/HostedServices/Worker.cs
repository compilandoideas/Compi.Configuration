using Compi.Configuration.Clean.Service.Common;
using Compi.Configuration.Clean.Service.Core.Application.Commands.SendNotificationError;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Compi.Configuration.Clean.Service.HostedServices
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _services;

        public Worker(ILogger<Worker> logger, IConfiguration configuration, IServiceProvider services)
        {

            _logger = logger  ??
               throw new ArgumentNullException(nameof(logger));

            _configuration = configuration ??
               throw new ArgumentNullException(nameof(configuration));

            _services = services ??
               throw new ArgumentNullException(nameof(services));

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation(_configuration.GetSection("var").Value);
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);


                var to = "xx";
                var subject = "xx";
                var from = "xx";
                var date = "55";


                using var scope = _services.CreateScope();
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                Result result = await mediator.Send(new SendNotificationErrorCommand(to, subject, from, date), stoppingToken);
             

            }
        }
    }
}

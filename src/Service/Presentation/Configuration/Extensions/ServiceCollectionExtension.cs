using Compi.Configuration.Service.Common;
using Compi.Configuration.Service.Presentation.Controllers;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Compi.Configuration.Service.Presentation.Configuration.Extensions
{
    public static class ServiceCollectionExtension
    {


        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {


            services.AddSingleton<NotificationController>();


            return services;
        }


        public static IServiceCollection AddMediator(this IServiceCollection services)
        {

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PipelineValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }




    }
}

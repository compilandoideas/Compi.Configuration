using Compi.Configuration.Service.Common;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Compi.Configuration.Service.Presentation.Configuration.Extensions
{
    public static class ServiceCollectionExtension
    {


       


        public static IServiceCollection AddMediator(this IServiceCollection services)
        {

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PipelineValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }




    }
}

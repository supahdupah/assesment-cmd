using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Operations.Features.v1;

namespace Importer.ServiceExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddV1Services(this IServiceCollection services)
        {
            services.AddSingleton<IHandler<Operations.Features.v1.ImportCapterra.Command>, Operations.Features.v1.ImportCapterra.Handler>();
            services.AddSingleton<IHandler<Operations.Features.v1.ImportSoftwareAdvice.Command>, Operations.Features.v1.ImportSoftwareAdvice.Handler>();
            
            return services;
        }
    }
}

using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Operations.Shared;
using System.Reflection;

namespace Operations.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddV1Services(this IServiceCollection services)
        {
            services.AddSingleton<IFileReader, FileReader>();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}

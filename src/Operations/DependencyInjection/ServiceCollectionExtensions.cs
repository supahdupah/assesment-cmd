using Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Operations.Features.v1.ImportCapterra.Deserializer;
using Operations.Features.v1.ImportSoftwareAdvice.Deserializer;
using Operations.Shared;
using System.Reflection;

namespace Operations.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddV1Services(this IServiceCollection services)
        {
            services.AddSingleton<IFileReader, FileReader>();
            services.AddSingleton<IJsonDeserializer, JsonDeserializer>();
            services.AddSingleton<IYamlDeserializer, YamlDeserializer>();
            services.AddSingleton<IProductRepository, ProductRepository>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}

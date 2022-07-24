using Importer;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Operations.DependencyInjection;
using System.Reflection;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var hostBuilder = CreateHostBuilder(args);

        await hostBuilder.RunConsoleAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostingContext, services) =>
            {
                services.AddMediatR(Assembly.GetExecutingAssembly());
                services.AddSingleton<IHostedService, App>();
                services.AddV1Services();
            });
}
//further
//if the process automated? cache/circuit breakers/object logging/fallbacks?
//later exception handling / fallbacks / retries if necessary
//the imported data could have many structures after (one object goes to database for sure + other during the process could be used/sent anywhere if needed)

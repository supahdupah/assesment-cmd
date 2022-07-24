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
                //db context if needed
                //oth
                services.AddMediatR(Assembly.GetExecutingAssembly());
                services.AddSingleton<IHostedService, App>();
                services.AddV1Services();
            });
}
//one databae + swap to another one later
//1. cmd
//2. 2 sources ( + one more later) / different format / strategy pattern? should think about this if needed at the end depends on the slice
//could try vertical slice for each source also or one for both (depends whats after)
//3.should / could do feature / version
//4.Command Handler(validate / read / parse ?/ insert to database)
//file read
//5. Validations for files / exception handlers

//6. Repo
//7. Models

//logging
//DI?
//unit tests / how to run

//further
//if the process automated? cache/circuit breakers/object logging/fallbacks?
//later exception handling / fallbacks / retries if necessary
//the imported data could have many structures after (one object goes to database for sure + other during the process could be used/sent anywhere if needed)

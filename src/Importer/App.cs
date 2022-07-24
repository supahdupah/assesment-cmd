using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Operations.Features.v1.ImportCapterra;
using Operations.Features.v1.ImportSoftwareAdvice;

namespace Importer
{
    public class App : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public App(ILogger<App> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var exit = false;
            while (exit == false)
            {
                Console.WriteLine("Select and enter the number of your chosen source to process");
                Console.WriteLine("\n 1. Capterra");
                Console.WriteLine("\n 2. Software Advice");

                Console.WriteLine("\n 4. Exit Program \n");

                var input = Console.ReadLine();
                int selection;
                var isInt = int.TryParse(input, out selection);

                if (!isInt)
                {
                    Console.WriteLine("Selection and entered key must be a number \n");
                }

                switch (selection)
                {
                    case 1:
                        using (var scope = _serviceScopeFactory.CreateScope())
                        {
                            var _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                            var request = new ImportCapterraRequest()
                            {
                                FilePath = FileSelector.GetFilePath(SourceType.Capterra)
                            };

                            var result = await _mediator.Send(request, cancellationToken);
                            Console.WriteLine("\n Capterra Result: "+ result.ImportedData);
                        }
                        break;
                    case 2:
                        using (var scope = _serviceScopeFactory.CreateScope())
                        {
                            var _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                            var request = new ImportSoftwareAdviceRequest()
                            {
                                FilePath = FileSelector.GetFilePath(SourceType.SoftwareAdvice)
                            };

                            var result = await _mediator.Send(request, cancellationToken);
                            Console.WriteLine("\n SoftwareAdvice Result: " + result.ImportedData);
                        }
                        break;
                    case 4:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

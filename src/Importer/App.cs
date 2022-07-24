using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Operations.Shared;

namespace Importer
{
    //mediatr
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
                Console.WriteLine("Select and enter the number which source to process");
                Console.WriteLine("\n 1. Capterra");
                Console.WriteLine("\n 2. Software Advice");
                Console.WriteLine("\n 3. All"); // if have time later

                Console.WriteLine("\n 4. Exit Program \n");

                var input = Console.ReadLine();
                int selection;
                var isInt = int.TryParse(input, out selection);

                if (!isInt)
                {
                    Console.WriteLine("Selection and entered key must be a number \n");
                    //return;
                }


                // split/refactor later if needed with a selector/strategy
                // 
                var capterraHandler = new Operations.Features.v1.ImportCapterra.Handler();
                var softwareAdviceHandler = new Operations.Features.v1.ImportSoftwareAdvice.Handler(new FileReader());

                switch (selection)
                {
                    case 1:
                        await capterraHandler.HandleAsync(new Operations.Features.v1.ImportCapterra.Command() { FileName = Constants.Constants.CAPTERRA_FILE_NAME });
                        break;
                    case 2:
                        await softwareAdviceHandler.HandleAsync(new Operations.Features.v1.ImportSoftwareAdvice.Command() { FileName = Constants.Constants.SOFTWAREADVICE_FILE_NAME });
                        break;
                    case 4:
                        exit = true;
                        break;
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

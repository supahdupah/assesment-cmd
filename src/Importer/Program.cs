// See https://aka.ms/new-console-template for more information

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
        return;
    }


    // split/refactor later if needed with a selector/strategy
    // 
    var capterraHandler = new Operations.Features.v1.ImportCapterra.Handler();
    var softwareAdviceHandler = new Operations.Features.v1.ImportSoftwareAdvice.Handler();

    switch (selection)
    {
        case 1:
            await capterraHandler.HandleAsync(new Operations.Features.v1.ImportCapterra.Command() { FilePath = });
            break;
        case 2:
            await softwareAdviceHandler.HandleAsync( new Operations.Features.v1.ImportSoftwareAdvice.Command());
            break;
        case 4:
            exit = true;
            break;
    }
}

//public class Handler
//{
//    public async Task Handle()
//    {
//        return;
//    }

//}

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

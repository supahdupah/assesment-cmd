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
    int selection = 0;
    var isInt = int.TryParse(input, out selection);

    if (!isInt)
    {
        Console.WriteLine("Selection and entered key must be a number \n");
    }
    var handler = new Handler();
    switch (selection)
    {
        case 0: 
            await handler.Handle();
            break;
        case 1:
            await handler.Handle();
            break;
        case 2:
            await handler.Handle();
            break;
        case 4:
            exit = true;
            break;
    }
}
public class Handler
{
    public async Task Handle()
    {
        return;
    }
    //validate file
    //read
    //parse
    //insert to db
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

# assesment-cmd
## How to run the application?
Requirements - .NET 6 (find it here https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
1. If you have Visual Studio  
      -> Clone this repository 
      -> "Build" solution inside VS
      -> Select "Importer" project as startup project
      -> Run with "Debug" or "Release"
2. If you do not have visual studio (.NET 6 still required)
      -> Download file "release.rar" (https://github.com/supahdupah/assesment-cmd/releases/tag/v1.0.0)
      -> Extract files
      -> Run "Importer.exe"
3. If you want to run unit tests - currently with Visual Studio. xUnit Tests can be found in "tests/Operations.Tests"
      
## Things to Improve/Missing/Redo?

1. Add validators/validations/guards
2. Exception handling
3. Logging
4. Finish add database/repos (dont know requirements)
5. Pretify console/output
6. Overall cleanup
7. Add more tests
8. Move FileReader if necessary
9. Add falbacks/"circuit breakers" depends on requirements
10. Add multitenancy depends on requirements
11. Check benchmarks if needed


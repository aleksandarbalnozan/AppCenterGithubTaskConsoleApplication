# Initialize the project setup and run unit tests. 

# Requirements: dotnet cli, dotnet .net 
dotnet build "$PSScriptRoot\AppCenterGithubTaskConsoleApplication"

# Run unit tests 
dotnet test "$PSScriptRoot\AppCenterGithubTaskConsoleApplication.Test"

# AppCenterGithubTaskConsoleApplication
- To download this project execute below code in cmd/powershell:
```
git clone https://github.com/aleksandarbalnozan/AppCenterGithubTaskConsoleApplication.git
```
# **Brief description of the project:**
- Overall this project prints all available branches and trigger build on every available branch printing its status every 125s

# **How to execute the code**
 **NOTE**
How to execute the code? 

Run init.ps1 script to build the code and run unit tests:

1. Open powershell 
2. CD into root directory 
3. Run ./init.ps1 

**OR**

- in the root folder of the application execute following code:
```
dotnet build
```
after executing the command, you'll see two new folders, `obj` and `bin`
you will want to go to the `bin\Debug\net5.0` and execute the `AppCenterGithubTaskConsoleApplication.exe` application
**OR**
after building the project, in the root directory, you can just execute:
```
dotnet run
```
which will execute the application

# **Required tools to run this application:**
- .NET CLI ([Download SDK](https://dotnet.microsoft.com/en-us/download/dotnet/5.0))
- .NET 5 Runtime ([Download runtime](https://dotnet.microsoft.com/en-us/download/dotnet/5.0))

# **TODO:**
- Implementing Unit-tests
- Objects cleanup
- Furter code improvments

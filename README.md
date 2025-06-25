# Learning System Management Project

This repository contains a starter ASP.NET Core Web API project (`LSM2`) and a small console application (`SystemManagementTutorial`) that demonstrates basic system management tasks.

## Projects

- **LSM2** – Default web API project generated with the .NET SDK.
- **SystemManagementTutorial** – Console application that prints system information and running processes.

## Building

Both projects target .NET 8.0. Install the .NET SDK and run:

```bash
dotnet build LSM2.sln
```

Run the tutorial project with:

```bash
dotnet run --project SystemManagementTutorial/SystemManagementTutorial.csproj
```

The output lists system details and running processes, providing a starting point for learning basic system management in C#.

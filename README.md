# E-Banking-API

Hello guys, this is first API that i wrote in my own.This API simulate real world application, i.e Banking Application.In this API you can CRUD user, CRUD account, and simulate transfer money between two account.

## Requirement for this project :
- .NET 5 SDK 
- Visual Studio
- SQL Server 2016 or higher

## How to run this project
Open `appsettings.json` and then set connection string :

### #1
```
"ConnectionStrings": {
    "MainConnection": "Data source=YOUR_DATA_SOURCE;Initial Catalog=YOUR_DB;User Id=YOUR_ID;Password=YOUR_PASSWORD;"
  }
```

### #2
Run migration and seeder using command `update-database`

### #3
Run Application ( hit F5 to start with debugging mode, or CTRL + F5 to start without debugging)

## Application Design Pattern
- Repository Pattern
- Dto Pattern

## What i've learned from this project
- Repository Pattern
- Dto Pattern
- CRUD operation using Entity Framework
- Create migration and seeder using Entity Framework
- Mapping between dto class and domain class using AutoMapper
- Custom mapping properties in AutoMapper
- Dependency Injection in ASP.NET Core Web API

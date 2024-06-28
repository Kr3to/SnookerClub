![diagram](https://github.com/Kr3to/SnookerClub/assets/89159808/32853dbe-aec3-46c7-9d58-4b3518be39dd)

# SnookerClub Documentation

## Description

SnookerClub is an ASP.NET Core project in the Snooker theme which contais functionalities such as:

- Register and login
- Distinct roles (user and admin) with different accesses around the app
- Connection to the database with 4 custom entites (2 of them in the relationship) and a bunch of entities from Identity module
- Onion architecture layout which prevenets unauthorized layers to access data
- 2 microservices running on ports 5000 and 5001 which allow users to add players and matches to the database
- Communication between microservices that highlists existing relationship in the database
- A reservations tab which allows user to view them and admin to interact with them
- Unit and integration tests (10 total)

Technologies used:

- ASP.NET Core
- Idnetity Module
- Entity Framework
- SQLite
- Swagger
- xunit & Moq

## Requirements 

- Code Editor of choice (preferably Visual Studio)
- Database of choice
- Dotnet 6.0 or above
- SDK & Runtime

## Installation

Easiet way to start would be to clone this repository to your local machine.

Then make sure you have all the necessary packages installed, including:

- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.AspNetCore.Identity.UI
- Microsoft.AspNetCore.OpenApi
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.InMemory
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.NET.Test.Sdk
- Moq
- Swashbuckle.AspNetCore
- xunit
- xunit.runner.visualstudio

In this project mosty used .NET version is 6.0 and for packages It's 6.0.25. It's highly recommended to follow these versions to ensure correct bulding and running.

You can install these packages via NuGet packet manager directly in Visual Studio or through command line:
`
dotnet add package <package_name> --version <package_version>
`
Next step would be to migrate and update the database by running these command from the main project directory.

via terminal:
`
dotnet ef migrations add <your_migration_name>
`
via NuGet console:
`
Add-migration <your_migration_name>
`

And then update.

via terminal:
`
dotnet ef database update
`

via NuGet console:
`
Update-database
`







## Configuration

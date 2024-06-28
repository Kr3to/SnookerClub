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
At that point you should be ready to go, however there are 2 thing to check still:

In the appsettings.json my database is specified, if you wish to change it adjust this line.
`
"AllowedHosts": "*",
"ConnectionStrings": {
  "ApplicationDbContextConnection": "<your_database>"
}
`
Then check if the ports on which the apps are running are allowed by your firewall and not used by any other application, check launchSettings.json in each of the project's Properties.
`
"applicationUrl": "https://localhost:7151;http://localhost:5066",
`
`
"applicationUrl": "http://localhost:5000",
`
`
"applicationUrl": "http://localhost:5001",
`
By default the ports are 7151 for the main app, 5000 for player microservice and 5001 for match microservice.

Last thing is to ensure the projects are ran together, you can achieve that by right clicking on the solution and "Set startup projects". Choose SnookerClub, PlayerService and MatchService.

`
dotnet build
`
`
dotnet run
`

## Configuration

Default users in the database are:

Admin
Email: admin@example.com
Username: admin
Password: 1234Abcd!

User
Email: user@example.com
Username: userexample
Password: user123PASSW!@#

Default hardcoded data in the database is:

Reservation entity:

- Id = 1, CustomerName = "John Doe", PlayTimeHours = 2, ReservationDate = new DateTime(2015, 11, 21)
- Id = 2, CustomerName = "Jane Smith", PlayTimeHours = 3, ReservationDate = new DateTime(2016, 11, 21)

HallOfFame entity:

- Id = 1, Name = "Ronnie O'Sullivan", Age = 45, Titles = 7
- Id = 2, Name = "Stephen Hendry", Age = 52, Titles = 7
- Id = 3, Name = "Steve Davis", Age = 63, Titles = 6 
- Id = 4, Name = "Mark Selby", Age = 41, Titles = 4
- Id = 5, Name = "John Higgins", Age = 49, Titles = 4

### Tests

Project also contains 10 tests which are ensuring that controllers are working properly and entities match actual table layout.

You can run them by clicking Test -> Test Explorer -> Run all tests.

Or via terminal:
`
cd <test_path>
`
`
dotnet test
`





Author: Mateusz Kręt

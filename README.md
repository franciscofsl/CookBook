### 🍳 CookPad Replica in C# with Domain-Driven Design (DDD) 📚

## Project Description

CookBook is a recipe management application implemented in C# using the principles of Domain-Driven Design (DDD). This project aims to replicate the basic functionality of the popular recipe platform, CookPad.

## Technologies Used

- **C#** 🚀: Primary programming language.
- **Blazor Web Assembly** 🌐: Framework for building web applications.
- **Entity Framework Core** 🗃️: ORM for data access.
- **SQL Server** 📂: Database for storing information.

## Setup and Execution

1. **Clone the repository** 🧬.
2. **Open the solution** 🖥️ in your preferred development environment.
3. **Configure Docker instance** 🐳 with `docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=SqlServer_Docker2023" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge`
4. **Run the migration** 🚀 to create the database: `dotnet ef database update`.
5. **Run CookPad.Blazor.Server** 🚀.

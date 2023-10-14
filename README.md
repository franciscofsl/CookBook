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
3. **Download Docker image** 🐳 with `docker pull mcr.microsoft.com/mssql/server:2019-latest`
4. **Configure Docker instance** 🐳 with `docker run -d --name sql-cookbook-server -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=SqlServer_Docker2023" -p 1434:1433 mcr.microsoft.com/mssql/server:2019-latest`
5. **Run the migration** 🚀 to create the database: `dotnet ef database update`.
6. **Run CookPad.Blazor.Server** 🚀.

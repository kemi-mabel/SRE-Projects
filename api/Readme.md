# Student CRUD REST API

This is a simple CRUD REST API for managing student information built using C# and .NET.

## Features

- Add a new student
- Get all students
- Get a student by ID
- Update existing student information
- Delete a student record

## Setup Instructions

### Prerequisites

- .NET 8 SDK or later
- SQL Server (you can use Docker to run a SQL Server instance)
- Environment variable `DefaultConnection` set with your SQL Server connection string

### Running the API

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/student-api.git
   cd student-api
Set the environment variable for the connection string:

On macOS/Linux:
export DefaultConnection="Server=localhost;Database=StudentDb;User Id="youruserid";Password="yourpassword";TrustServerCertificate=True;"

On Windows (Command Prompt):
setx DefaultConnection "Server=localhost;Database=StudentDb;User Id=SA;Password=MyStrongPass123;TrustServerCertificate=True;"

Run the API:
dotnet run
Open your browser and navigate to https://localhost:5001/swagger to view the Swagger UI.

Running Tests
To run the tests, use the following command:
dotnet test

Makefile
You can use the provided Makefile to simplify the build and run process:

makefile
run:
    export DefaultConnection="Server=localhost;Database="yourdb";User Id="yourId";Password="yourpassword";TrustServerCertificate=True;"
    dotnet run

test:
    dotnet test

To run the API using the Makefile, use:
cd to API project
make run

To run the tests using the Makefile, use:
CD to your test project
make test


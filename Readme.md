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
2. Set the environment variable for the connection string:

    On macOS/Linux:

    ```bash
    export DefaultConnection="Server=localhost;Database=yourdb;User Id="youruserid";Password="yourpassword";TrustServerCertificate=True;"

    2. On Windows (Command Prompt):
    ```bash
    setx DefaultConnection "Server=localhost;Database=yourdb;User Id=yourid;Password=yourpassword;TrustServerCertificate=True;"

3. Run the API:
    cd api
    ```bash
    dotnet run

4. Open your browser and navigate to https://localhost:5001/swagger to view the Swagger UI.

5. Running Tests
    To run the tests, use the following command:
    cd StudentAPI.Tests
    ```bash
    dotnet test

## Makefile

You can use the provided Makefile to simplify the build and run process:

To run the API using the Makefile, use:
cd api
    ```bash
    make run

To run the tests using the Makefile, use:
    cd StudentAPI.Tests
    ```bash
    make test


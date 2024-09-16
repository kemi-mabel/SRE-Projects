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

1. **Clone the Repository**:

    ```bash
    git clone https://github.com/yourusername/student-api.git
    cd student-api
    ```

2. **Set the Environment Variable for the Connection String**:

    - **On macOS/Linux**:

      ```bash
      export DefaultConnection="Server=localhost;Database=yourdb;User Id=youruserid;Password=yourpassword;TrustServerCertificate=True;"
      ```

    - **On Windows**:

      ```bash
      setx DefaultConnection "Server=localhost;Database=yourdb;User Id=youruserid;Password=yourpassword;TrustServerCertificate=True;"
      ```

3. **Run the API**:

    ```bash
    cd api
    dotnet run
    ```

4. **View the Swagger UI**:
   Open your browser and navigate to `https://localhost:5001/swagger` to view the Swagger UI.

### Running Tests

To run the tests, use the following command:

```bash
cd StudentAPI.Tests
dotnet test


Makefile
You can use the provided Makefile to simplify the build and run process. Below are the instructions for using the Makefile:

To Run the API Using the Makefile:
cd api
make run
To Run the Tests Using the Makefile:
cd StudentAPI.Tests
make test

## Docker

### Build the Docker Image

```bash
docker build -t studentapi:1.0 .

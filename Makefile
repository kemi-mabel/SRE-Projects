build:
	@echo "Building the API..."
	dotnet build

test:
	@echo "Running tests..."
	dotnet test StudentAPI.Tests/StudentAPI.Tests.csproj # Specify the test project path

lint:
	@echo "Running code linting..."
	dotnet build

build:
	@echo "Building the API..."
	dotnet build

test:
	@echo "Running tests..."
	dotnet test

lint:
	@echo "Running code linting..."
	dotnet build


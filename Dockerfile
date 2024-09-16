# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["api/api.csproj", "api/"]
RUN dotnet restore "api/api.csproj"
COPY . .
# Copy the entrypoint script
COPY entrypoint.sh .
# Make sure the script is executable
RUN chmod +x entrypoint.sh
WORKDIR "/src/api"
RUN dotnet build "api.csproj" -c Release -o /app/build

FROM build AS publish 
RUN dotnet publish "api.csproj" -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80 
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api.dll"]

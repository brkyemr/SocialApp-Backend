# Use the .NET Core SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy the solution file and restore dependencies
COPY *.sln ./

# Copy the project files into the appropriate directories
COPY Core/SocialApp.Application/SocialApp.Application.csproj Core/SocialApp.Application/
COPY Core/SocialApp.Domain/SocialApp.Domain.csproj Core/SocialApp.Domain/
COPY Core/SocialApp.Mapper/SocialApp.Mapper.csproj Core/SocialApp.Mapper/
COPY Infrastructure/SocialApp.Infrastructure/SocialApp.Infrastructure.csproj Infrastructure/SocialApp.Infrastructure/
COPY Infrastructure/SocialApp.Persistence/SocialApp.Persistence.csproj Infrastructure/SocialApp.Persistence/
COPY Presentation/SocialApp.Api/SocialApp.Api.csproj Presentation/SocialApp.Api/

# Restore dependencies
RUN dotnet restore

# Copy the rest of the source code and build the application
COPY . ./
RUN dotnet build -c Release -o out

# Publish the application
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 5002
ENV ASPNETCORE_URLS=http://+:5002
ENTRYPOINT ["dotnet", "SocialApp.Api.dll", "--environment=Development"]

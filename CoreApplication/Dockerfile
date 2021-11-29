FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /WebApp
EXPOSE 80


# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY WebApp/*.csproj ./WebApp/
COPY WebApp.Tests/*.csproj ./WebApp.Tests/
RUN dotnet restore

# copy everything else and build app
COPY . .
WORKDIR /source/WebApp

WORKDIR /source/WebApp
RUN dotnet build -c Release -o /WebApp

WORKDIR /source/WebApp.Tests
RUN dotnet build -c Release -o /WebApp

FROM build AS publish
RUN dotnet publish -c Release -o /WebApp

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /WebApp
COPY --from=build /WebApp ./
ENTRYPOINT ["dotnet", "WebApp.dll"]
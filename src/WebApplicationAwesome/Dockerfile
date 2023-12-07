#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["NuGet.config", "."]
COPY ["src/WebApplicationAwesome/WebApplicationAwesome.csproj", "src/WebApplicationAwesome/"]
RUN dotnet restore "./src/WebApplicationAwesome/./WebApplicationAwesome.csproj"
COPY . .
WORKDIR "/src/src/WebApplicationAwesome"
RUN dotnet build "./WebApplicationAwesome.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebApplicationAwesome.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplicationAwesome.dll"]
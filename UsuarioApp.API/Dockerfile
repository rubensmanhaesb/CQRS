FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["UsuarioApp/UsuarioApp.API/UsuarioApp.API.csproj", "UsuarioApp.API/"]

RUN dotnet restore "./UsuarioApp.API/./UsuarioApp.API.csproj"

COPY . .
WORKDIR "/src/UsuarioApp.API"

RUN dotnet build "./UsuarioApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./UsuarioApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UsuarioApp.API.dll",  "--environment", "Development"]
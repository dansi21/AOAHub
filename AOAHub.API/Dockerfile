FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# Build and publish the API
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AOAHub.API/AOAHub.API.csproj", "AOAHub.API/"]
COPY ["AOAHub.Db/AOAHub.Db.csproj", "AOAHub.Db/"]
COPY ["AOAHub.Domain/AOAHub.Domain.csproj", "AOAHub.Domain/"]
RUN dotnet restore "./AOAHub.API/AOAHub.API.csproj"
COPY . .
WORKDIR "/src/AOAHub.API"
RUN dotnet publish "./AOAHub.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false


# The card database ships inside the image; it is opened read-only, so a data update is a redeploy.
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
COPY AOAHub.Db/CardDb.db /app/data/CardDb.db
ENV ConnectionStrings__DefaultConnection="Data Source=/app/data/CardDb.db;Mode=ReadOnly"
ENTRYPOINT ["dotnet", "AOAHub.API.dll"]

# Build and publish the Blazor WebAssembly app to static files
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AOAHub.UI/AOAHub.UI.csproj", "AOAHub.UI/"]
COPY ["AOAHub.Domain/AOAHub.Domain.csproj", "AOAHub.Domain/"]
RUN dotnet restore "./AOAHub.UI/AOAHub.UI.csproj"
COPY . .
WORKDIR "/src/AOAHub.UI"
RUN dotnet publish "./AOAHub.UI.csproj" -c $BUILD_CONFIGURATION -o /app/publish


# Serve the static files; the droplet's Caddy proxies to this container.
FROM caddy:2-alpine AS final
COPY AOAHub.UI/Caddyfile /etc/caddy/Caddyfile
COPY --from=build /app/publish/wwwroot /srv
EXPOSE 80

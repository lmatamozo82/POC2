FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
EXPOSE 80
EXPOSE 443
WORKDIR /src
COPY ["Deneva.Adapters.Database.MySQL/Deneva.Adapters.Database.MySQL.csproj", "Deneva.Adapters.Database.MySQL/"]
COPY ["Deneva.Adapters.Log.Serilog/Deneva.Adapters.Log.Serilog.csproj", "Deneva.Adapters.Log.Serilog/"]
COPY ["Deneva.Adapters.Storage.Filesystem/Deneva.Adapters.Storage.Filesystem.csproj", "Deneva.Adapters.Storage.Filesystem/"]
COPY ["Deneva.Core.Application/Deneva.Core.Application.csproj", "Deneva.Core.Application/"]
COPY ["Deneva.Core.Domain/Deneva.Core.Domain.csproj", "Deneva.Core.Domain/"]
COPY ["Deneva.Adapters.WebAPI.Playlist.Host/Deneva.Adapters.WebAPI.Playlist.Host.csproj", "Deneva.Adapters.WebAPI.Playlist.Host/"]

RUN dotnet restore "Deneva.Adapters.WebAPI.Playlist.Host/Deneva.Adapters.WebAPI.Playlist.Host.csproj"
COPY . .
WORKDIR "/src/Deneva.Adapters.WebAPI.Playlist.Host"
RUN dotnet build "Deneva.Adapters.WebAPI.Playlist.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Deneva.Adapters.WebAPI.Playlist.Host.csproj" -c Release -o /app/publish

FROM publish AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Deneva.Adapters.WebAPI.Playlist.Host.dll"]
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AirportGateway/AirportGateway.Api/AirportGateway.Api.csproj", "AirportGateway/AirportGateway.Api/"]
COPY ["AirportGateway/AirportGateway.Api/AirportGateway.App.csproj", "AirportGateway/AirportGateway.App/"]
RUN dotnet restore "AirportGateway/AirportGateway.Api/AirportGateway.Api.csproj"
COPY . .
WORKDIR "/src/AirportGateway/AirportGateway.Api"
RUN dotnet build "AirportGateway.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AirportGateway.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AirportGateway.Api.dll"]

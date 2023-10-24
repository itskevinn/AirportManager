FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AirportGateway/AirportGateway.csproj", "AirportGateway/"]
RUN dotnet restore "AirportGateway/AirportGateway.csproj"
COPY . .
WORKDIR "/src/AirportGateway"
RUN dotnet build "AirportGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AirportGateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AirportGateway.dll"]

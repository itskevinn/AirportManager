FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY ["AirportGateway.Api/AirportGateway.Api.csproj", "AirportGateway.Api/"]
COPY ["AirportGateway.App/AirportGateway.App.csproj", "AirportGateway.App/"]

RUN dotnet restore "AirportGateway.Api/AirportGateway.Api.csproj"
COPY . .
WORKDIR "/src/AirportGateway.Api"
RUN dotnet build "AirportGateway.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AirportGateway.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AirportGateway.Api.dll"]

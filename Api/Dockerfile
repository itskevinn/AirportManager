FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AirportManagement.Api/AirportManagement.Api.csproj", "AirportManagement.Api/"]
COPY ["AirportManagement.Domain/AirportManagement.Domain.csproj", "AirportManagement.Domain/"]
COPY ["AirportManagement.Infrastructure/AirportManagement.Infrastructure.csproj", "AirportManagement.Infrastructure/"]
COPY ["AirportManagement.Application/AirportManagement.Application.csproj", "AirportManagement.Application/"]

RUN dotnet restore "AirportManagement.Api/AirportManagement.Api.csproj"
COPY . .
WORKDIR "/src/AirportManagement.Api"
RUN dotnet build "AirportManagement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AirportManagement.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AirportManagement.Api.dll"]

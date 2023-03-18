FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY "Database/Database.csproj" "Database/Database.csproj"
COPY "Domain/Domain.csproj" "Domain/Domain.csproj"
COPY "Infrastructure/Infrastructure.csproj" "Infrastructure/Infrastructure.csproj"
COPY . .
WORKDIR "/src/Database"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BroFixe.Database.dll"]


FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Install Node.js
RUN curl -fsSL https://deb.nodesource.com/setup_14.x | bash - \
    && apt-get install -y \
        nodejs \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /src
COPY "bro-fixe.sln" "bro-fixe.sln"
COPY "Domain/Domain.csproj" "Domain/Domain.csproj"
COPY "Infrastructure/Infrastructure.csproj" "Infrastructure/Infrastructure.csproj"
COPY "Web/Web.csproj" "Web/Web.csproj"
COPY "Web.Tests.Integration/Web.Tests.Integration.csproj" "Web.Tests.Integration/Web.Tests.Integration.csproj"
RUN dotnet restore "bro-fixe.sln"
COPY . .
WORKDIR "/src/Web"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BroFixe.Web.dll"]

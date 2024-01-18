FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MerchandiseManager.Api/MerchandiseManager.Api.csproj", "MerchandiseManager.Api/"]
COPY ["MerchandiseManager.Core/MerchandiseManager.Core.csproj", "MerchandiseManager.Core/"]
COPY ["MerchandiseManager/MerchandiseManager.Utility.csproj", "MerchandiseManager/"]
COPY ["MerchandiseManager.DAL/MerchandiseManager.DAL.csproj", "MerchandiseManager.DAL/"]
COPY ["MerchandiseManager.Application/MerchandiseManager.Application.csproj", "MerchandiseManager.Application/"]
RUN dotnet restore "./MerchandiseManager.Api/./MerchandiseManager.Api.csproj"
COPY . .
WORKDIR "/src/MerchandiseManager.Api"
RUN dotnet build "./MerchandiseManager.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MerchandiseManager.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MerchandiseManager.Api.dll"]
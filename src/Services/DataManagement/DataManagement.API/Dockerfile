#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/DataManagement/DataManagement.API/DataManagement.API.csproj", "Services/DataManagement/DataManagement.API/"]
RUN dotnet restore "Services/DataManagement/DataManagement.API/DataManagement.API.csproj"
COPY . .
WORKDIR "/src/Services/DataManagement/DataManagement.API"
RUN dotnet build "DataManagement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DataManagement.API.csproj" -c Release -o /app/publish /p:UseAppHost=false /p:PublishReadyToRun=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DataManagement.API.dll"]
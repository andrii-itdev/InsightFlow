#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["aty_service_core/aty_service_core.csproj", "aty_service_core/"]
RUN dotnet restore "aty_service_core/aty_service_core.csproj"
COPY . .
WORKDIR "/src/aty_service_core"
RUN dotnet build "aty_service_core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "aty_service_core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "aty_service_core.dll"]
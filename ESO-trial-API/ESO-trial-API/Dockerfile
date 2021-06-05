#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["ESO-trial-API/ESO-trial-API.csproj", "ESO-trial-API/"]
RUN dotnet restore "ESO-trial-API/ESO-trial-API.csproj"
COPY . .
WORKDIR "/src/ESO-trial-API"
RUN dotnet build "ESO-trial-API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ESO-trial-API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ESO-trial-API.dll"]

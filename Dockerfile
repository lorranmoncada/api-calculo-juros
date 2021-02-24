#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["CalcularJuros/CalcularJuros.csproj", "CalcularJuros/"]
COPY ["CalcularJuros.Api.Domain/CalcularJuros.Api.Domain.csproj", "CalcularJuros.Api.Domain/"]
COPY ["CalcularJuros.Api.Core/CalcularJuros.Api.Core.csproj", "CalcularJuros.Api.Core/"]
COPY ["CalcularJuros.Api.Application/CalcularJuros.Api.Application.csproj", "CalcularJuros.Api.Application/"]
RUN dotnet restore "CalcularJuros/CalcularJuros.csproj"
COPY . .
WORKDIR "/src/CalcularJuros"
RUN dotnet build "CalcularJuros.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalcularJuros.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet CalcularJuros.dll
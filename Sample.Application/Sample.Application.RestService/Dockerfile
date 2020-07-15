#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Sample.Application.RestService/Sample.Application.RestService.csproj", "Sample.Application.RestService/"]
RUN dotnet restore "Sample.Application.RestService/Sample.Application.RestService.csproj"
COPY . .
WORKDIR "/src/Sample.Application.RestService"
RUN dotnet build "Sample.Application.RestService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sample.Application.RestService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sample.Application.RestService.dll"]
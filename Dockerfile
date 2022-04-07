#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://*:8082
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["user-service-v1/user-service-v1.csproj", "user-service-v1/"]
RUN dotnet restore "user-service-v1/user-service-v1.csproj"
COPY . .
WORKDIR "/src/user-service-v1"
RUN dotnet build "user-service-v1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "user-service-v1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "user-service-v1.dll"]

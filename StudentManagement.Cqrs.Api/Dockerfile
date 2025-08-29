FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["StudentManagement.Cqrs.Api.csproj", "./"]
RUN dotnet restore "StudentManagement.Cqrs.Api.csproj"

COPY . .
RUN dotnet build "StudentManagement.CQRS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudentManagement.CQRS.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentManagement.CQRS.dll"]

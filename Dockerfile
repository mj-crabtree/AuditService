FROM mcr.microsoft.com/dotnet/sdk:8.0 as BUILD
WORKDIR /app
EXPOSE 80

COPY *.sln .
COPY AuditService.API/*.csproj ./AuditService.API/
COPY AuditService.Entities/*.csproj ./AuditService.Entities/
RUN dotnet restore

RUN dotnet tool install --global dotnet-ef

COPY AuditService.API/. ./AuditService.API/
COPY AuditService.Entities/. ./AuditService.Entities
WORKDIR /app/AuditService.API
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/AuditService.API/out ./

ENTRYPOINT ["dotnet", "AuditService.API.dll"]

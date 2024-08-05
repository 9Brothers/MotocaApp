FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app

COPY . ./

RUN dotnet publish src/Platform/Interfaces/CLI/Terminals/Motoca.Platform.Interfaces.CLI.Terminals.Migrator -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/out .

RUN rm /app/.env

ENV TZ=America/Sao_Paulo

ENTRYPOINT ["dotnet", "Motoca.Platform.Interfaces.CLI.Terminals.Migrator.dll"]
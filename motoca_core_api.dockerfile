FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app

COPY . ./

RUN dotnet publish src/Core/Interfaces/Http/Api/Motoca.Core.Interfaces.Http.Api.Common -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/out .

ENV TZ=America/Sao_Paulo

ENTRYPOINT ["dotnet", "Motoca.Core.Interfaces.Http.Api.Common.dll"]
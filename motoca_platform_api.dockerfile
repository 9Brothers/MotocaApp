FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app

COPY . ./

RUN rm src/Core/Interfaces/Http/Api/Motoca.Core.Interfaces.Http.Api.Common/appsettings.json
RUN rm src/Core/Interfaces/Http/Api/Motoca.Core.Interfaces.Http.Api.Common/appsettings.Development.json

RUN dotnet publish src/Platform/Interfaces/Http/Api/Motoca.Platform.Interfaces.Http.Api.MotocaApi -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/out .

ENV TZ=America/Sao_Paulo

ENTRYPOINT ["dotnet", "Motoca.Platform.Interfaces.Http.Api.MotocaApi.dll"]
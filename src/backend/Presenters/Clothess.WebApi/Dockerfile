FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY src/backend/Core/Clothess.Core/*.csproj src/backend/Core/Clothess.Core/
COPY src/backend/Core/Clothess.UseCases/*.csproj src/backend/Core/Clothess.UseCases/

COPY src/backend/Infra/Clothess.Persistense/*.csproj src/backend/Infra/Clothess.Persistense/

COPY src/backend/Presenters/Clothess.WebApi/*.csproj src/backend/Presenters/Clothess.WebApi/

RUN dotnet restore src/backend/Presenters/Clothess.WebApi/*.csproj

COPY src/backend/ src/backend/

WORKDIR /src/src/backend/Presenters/Clothess.WebApi
RUN dotnet publish -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "Clothess.WebApi.dll"]
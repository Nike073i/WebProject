FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY *.csproj .
RUN dotnet restore
COPY . ./
WORKDIR /src
RUN dotnet build -c Release --no-restore -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM build AS test
WORKDIR /app
COPY . .
ENTRYPOINT ["dotnet", "test", "--logger:trx"]

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "test"]

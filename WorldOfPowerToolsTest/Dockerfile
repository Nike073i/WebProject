# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
# WORKDIR /src

# COPY *.csproj .

#RUN dotnet restore
#COPY . ./

#RUN dotnet publish --no-restore -c Release -o /out

#FROM mcr.microsoft.com/dotnet/aspnet:6.0
#WORKDIR /app
#COPY --from=build-env /app/out .
#ENTRYPOINT ["dotnet", "WorldOfPowerToolsTest.dll"]

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
RUN dotnet test --no-restore

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "test"]

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


FROM microsoft/aspnetcore:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:6.0 AS build
WORKDIR /src
COPY WebProject/WordlOfPowerToolsTest.csproj WordlOfPowerToolsTest.csproj
RUN dotnet restore
COPY . .
WORKDIR /src
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WordlOfPowerToolsTest.dll"]

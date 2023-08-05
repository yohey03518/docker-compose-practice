FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY ./ ./
RUN dotnet restore 
RUN dotnet publish "mybot.csproj" -c Release -o published

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine

WORKDIR /app
COPY --from=build /app/published/ ./

ENTRYPOINT ["dotnet", "mybot.dll"]

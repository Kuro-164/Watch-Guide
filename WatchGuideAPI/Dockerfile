# -------- BUILD STAGE --------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project file and restore
COPY WatchGuideAPI.csproj .
RUN dotnet restore

# Copy the rest of the source code
COPY . .

# Build & publish
RUN dotnet publish -c Release -o /app/publish

# -------- RUNTIME STAGE --------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "WatchGuideAPI.dll"]

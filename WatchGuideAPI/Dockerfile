# -------- BUILD STAGE --------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy ONLY the API project file
COPY WatchGuideAPI/WatchGuideAPI.csproj WatchGuideAPI/
RUN dotnet restore WatchGuideAPI/WatchGuideAPI.csproj

# Copy API source code
COPY WatchGuideAPI/. WatchGuideAPI/

# Build & publish
WORKDIR /src/WatchGuideAPI
RUN dotnet publish -c Release -o /app/publish

# -------- RUNTIME STAGE --------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "WatchGuideAPI.dll"]

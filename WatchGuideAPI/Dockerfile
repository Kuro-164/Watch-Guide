# -------- BUILD STAGE --------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore ONLY API project
COPY WatchGuideAPI.csproj .
RUN dotnet restore WatchGuideAPI.csproj

# Copy remaining source
COPY . .

# Publish ONLY API project (NO solution)
RUN dotnet publish WatchGuideAPI.csproj -c Release -o /app/publish

# -------- RUNTIME STAGE --------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "WatchGuideAPI.dll"]

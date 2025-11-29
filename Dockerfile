# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only project file first
COPY HotelApp/HotelApp.csproj HotelApp/

RUN dotnet restore HotelApp/HotelApp.csproj

# Copy all files
COPY . .

RUN dotnet publish HotelApp/HotelApp.csproj -c Release -o /app

# Run stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app .

ENTRYPOINT ["dotnet", "HotelApp.dll"]

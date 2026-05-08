# Bygg‑image (SDK)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Arbetskatalog
WORKDIR /app

# Kopiera projektfilen och restore
COPY *.csproj ./
RUN dotnet restore

# Kopiera resten av projektet
COPY . .

# Bygg och publicera
RUN dotnet publish -c Release -o /app/publish

# Runtime‑image (liten och snabb)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

# Kopiera publicerad build
COPY --from=build /app/publish .

# Exponera porten som API:t kör på
EXPOSE 8080

# Starta API:t
ENTRYPOINT ["dotnet", "MormorDagny3.dll"]

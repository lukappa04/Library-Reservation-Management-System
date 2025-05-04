# STAGE 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /WebionChallenge

# Copia il file csproj
COPY WebionLibraryAPI.csproj ./

# Ripristina le dipendenze
RUN dotnet restore "WebionLibraryAPI.csproj"

# Copia tutto il resto del codice
COPY . .

# Compila il progetto
WORKDIR "/WebionChallenge"
RUN dotnet publish "WebionLibraryAPI.csproj" -c Release -o /app/publish

# STAGE 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copia l'output del build
COPY --from=build /app/publish .

# Espone la porta 8080 per l'API
EXPOSE 8080

# Imposta l'entrypoint per eseguire l'app
ENTRYPOINT ["dotnet", "WebionLibraryAPI.dll"]

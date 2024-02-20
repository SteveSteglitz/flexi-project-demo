# Verwende das offizielle Microsoft SQL Server-Image als Basis
FROM mcr.microsoft.com/mssql/server:2019-latest

# Setze Umgebungsvariablen für den SQL Server
ENV ACCEPT_EULA=Y \
    SA_PASSWORD=YourStrong!Passw0rd

# Öffne den SQL Server-Port
EXPOSE 1433

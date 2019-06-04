#!/bin/bash
set -e

# Create database migrations script
docker run -v $(pwd):/app -w /app -e DB_CONNECTION_STRING="nothing" \
    microsoft/dotnet:2.2-sdk \
    /bin/bash -c \
    "dotnet build src/HelloESDC.API/HelloESDC.API.csproj && \ 
    dotnet ef migrations script -i -o database/seed.sql -p src/HelloESDC.API/HelloESDC.API.csproj && \
    dotnet clean"
FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore HelloESDC.API.csproj

COPY . ./
RUN dotnet publish HelloESDC.API.csproj -c Release -o /app/out

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime

WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "HelloESDC.API.dll"]
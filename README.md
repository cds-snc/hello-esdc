# hello-esdc

## Project structure/files

- database (for seed .sql files)
- src
  - HelloESDC.API (.NET Core webapi project)
  - Web
    - WebSPA (where we'll build our sample SPA frontend)
    - WebWxT (where we'll build our sample WxT frontend)
- test (for tests - may move to sub-project folders?)

## Docker
There is a Dockerfile for the HelloESDC.API sub-project that will build a container for the API:

```
cd src/HelloESDC.API
docker build -t hello-esdc-api .
```

There are also empty Dockerfiles in the `src/Web/WebSPA` and `src/Web/WebWxT` folders for future use.

## Docker Compose
There is a basic docker-compose.yml file at the root that will bring up the api and a postgres database. This is just taken from some example code (see References below), we don't have to stick with Postgres. 

There currently is no interaction between the containers, just sample code at the moment.

You can bring up the containers using:

```
docker-compose up
```

And the api will be available at: `localhost:8000/api/values`

## Todo
There are quite a few pieces still missing, including:
- Tests
- CI
- Database model/scripts
- Entity Framework (for db)

## References
Medium post example of .net core webapi project with postgresql database:
- https://medium.com/front-end-weekly/net-core-web-api-with-docker-compose-postgresql-and-ef-core-21f47351224f
- https://github.com/rajvirtual/docker-aspnetcore-postgresql

Indepth article about Microservices Architecture in .NET, plus a reference application
- https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/
- https://github.com/dotnet-architecture/eShopOnContainers

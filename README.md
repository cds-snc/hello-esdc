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

## Running
There is a basic docker-compose.yml file at the root that will bring up the api and a postgres database. This is just taken from some example code (see References below), we don't have to stick with Postgres. 

There currently is no interaction between the containers, just sample code at the moment.

You can bring up the containers by doing this:

1. Navigate to project root in terminal
1. Generate migration script: `sh util/build_migrations.sh`
1. Launch Docker containers: `docker-compose up --build`

And the api will be available at: `localhost:8000/api/values`

To stop and reset:

1. Exit the apps: CTRL+C
1. Remove volumes: `docker-compose down`

## Todo
There are quite a few pieces still missing, including:
- Tests
- CI

## References
Medium post example of .net core webapi project with postgresql database:
- https://medium.com/front-end-weekly/net-core-web-api-with-docker-compose-postgresql-and-ef-core-21f47351224f
- https://github.com/rajvirtual/docker-aspnetcore-postgresql

Indepth article about Microservices Architecture in .NET, plus a reference application
- https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/
- https://github.com/dotnet-architecture/eShopOnContainers


## Deployment

A bunch of the infrastructure and helm stuff was modeled after this:
- https://github.com/core-process/aks-terraform-helm

```
# login to Azure and set subscription
az login
az account set --subscription <ID>

# prepare infrastructure configuration
cp ./infrastructure/terraform.tfvars.example ./infrastructure/terraform.tfvars
code ./infrastructure/terraform.tfvars

cd ./infrastructure
terraform init
terraform apply

# export variables for app deployment

# ... will be used by docker compose
export IMAGE_REGISTRY="$(terraform output CR_ENDPOINT)"
export IMAGE_LABEL="latest"

# ... will be used later (see open command in last line)
export APP_URL="https://$(terraform output k8s_ingress_fqdn)"

# build and push app
cd ../
docker-compose build
docker-compose push

```
# redis-cluster-dotnet-core-template
I am building a boilerplate project for a dotnet core api web service with redis cluster distributed caching


# https://github.com/bitnami/bitnami-docker-redis

# docker stop all
 docker stop $(docker ps -aq)

# run command
docker-compose up --detach --scale redis-master=1 --scale redis-replica=3

docker-compose --compatibility up --build

# pack the project template
dotnet pack

# to <GeneratePackageOnBuild>true</GeneratePackageOnBuild>   
dotnet build -c Release


# install template

dotnet new -i <package>

# create project

dotnet new redis-dotnet-core -n MyProject --force



# stop docker 
docker ps -q | xargs -L1 docker stop

# start docker
open --background -a Docker



# generate dev-cert ssl
dotnet dev-certs https --clean

dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p password

dotnet dev-certs https --trust
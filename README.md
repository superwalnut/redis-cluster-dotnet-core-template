# redis-cluster-dotnet-core-template
I am building a boilerplate project for a dotnet core api web service with redis cluster distributed caching


# https://github.com/bitnami/bitnami-docker-redis

# docker stop all
 docker stop $(docker ps -aq)

# run command
docker-compose up --detach --scale redis-master=1 --scale redis-replica=3 --scale redis-sentinel=3

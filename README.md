# Project Template - Redis Cluster + .Net Core 3.1 API + Docker

> This is a project template that saves your time create redis cluster in docker with a dotnet core app to consume from scratch. All you need to do is using docker-compose up and you already have 1 master + 3 slaves redis cluster.

**Languages & Tools**

- Redis
- Docker
- .Net Core 3.1
- ServiceStack.Redis

## Table of Contents

- [Installation](#installation)
- [Features](#features)
- [Contributing](#contributing)
- [Team](#team)
- [FAQ](#faq)
- [Support](#support)
- [License](#license)

---

## Installation

- Using `dotnet new -i <package>` to install the project template from nuget

```shell
$ dotnet new -i Superwalnut.RedisClusterTemplate
```

- Using `dotnet new redis-dotnet-core -n <your-project-name>` to create a project with your own project name using this template

```shell
$ dotnet new redis-dotnet-core -n MyFirstRedisProject -o MyFirstRedisProject
```

---


## Features


### Usage

- Go to the <project-folder>/docker, you will see `docker-compose.yml` file, this is where you can run

```shell
$ docker-compose --compatibility up --build
```

> update and install this package first

```shell
$ brew update
$ brew install fvcproductions
```

> now install npm and bower packages

```shell
$ npm install
$ bower install
```

## Documentation (Optional)

## Tests (Optional)

## FAQ

- **How do I do *specifically* so and so?**
    - No problem! Just do this.

---

## Support

Reach out to me at one of the following places!

- Website at <a href="http://fvcproductions.com" target="_blank">`fvcproductions.com`</a>
- Twitter at <a href="http://twitter.com/fvcproductions" target="_blank">`@fvcproductions`</a>
- Insert more social links here.

---

## Donations (Optional)

- You could include a <a href="https://cdn.rawgit.com/gratipay/gratipay-badge/2.3.0/dist/gratipay.png" target="_blank">Gratipay</a> link as well.

[![Support via Gratipay](https://cdn.rawgit.com/gratipay/gratipay-badge/2.3.0/dist/gratipay.png)](https://gratipay.com/fvcproductions/)


---

## License

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)

- **[MIT license](http://opensource.org/licenses/mit-license.php)**
- Copyright 2015 © <a href="http://fvcproductions.com" target="_blank">FVCproductions</a>.


-------


# redis-cluster-dotnet-core-template
I am building a boilerplate project for a dotnet core api web service with redis cluster distributed caching


# https://github.com/bitnami/bitnami-docker-redis

# docker stop all

ocker stop $(docker ps -a -q)
docker rm $(docker ps -a -q)

# run command
docker-compose up --detach --scale redis-master=1 --scale redis-replica=3

docker-compose --compatibility up --build -p redis

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
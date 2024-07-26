# Projeto Journal

## Database Mapping
![Modelagem Inicial](https://user-images.githubusercontent.com/32781707/181919692-b917390d-a48b-44ce-a0bc-ea246c3f345d.png)

## Swagger
![Screenshot from 2022-07-30 12-07-45](https://user-images.githubusercontent.com/32781707/181920406-d79ba6c7-c59f-44ef-a709-0ff5d65d46bb.png)

## Run Database with docker
docker run -p 3306:3306 --name maria-db -e MYSQL_ROOT_PASSWORD=root -d mariadb:10.5

## Frontend wih VueJs
![image](https://user-images.githubusercontent.com/32781707/181925521-e664c5e9-52c7-45d9-9984-aa5ad67fe152.png)

## Api 
https://doaj.org/

## Login Heroku
heroku container:login

## Deploy heroku Backend
heroku create find-journal-api

heroku container:push web -a find-journal-api

heroku container:release web -a find-journal-api

## Deploy heroku Front

heroku container:push web -a find-journal-front

heroku container:release web -a find-journal-api


## Implement on API

* [x] Entity Framework Core

* [x] RabbitMq

* [ ] Serilog

* [ ] Redis

* [ ] DockerFile / DockerCompose

* [x] Migrar Projeto .NET 8 

* [ ] DDD

* [ ] UPDATE

* [ ] DELETE

* [ ] JWT

* [x] IUnityOfWork

* [x] Dto's

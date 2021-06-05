# eCommerceMicroservices

### Docker Command (Reference: https://blog.baudson.de/blog/stop-and-remove-all-docker-containers-and-images)
- List all containers (only IDs) > $ docker ps -aq
- Stop all running containers > $ docker stop $(docker ps -aq)
- Remove all containers > $ docker rm $(docker ps -aq)
- Remove all images > $ docker rmi $(docker images -q)

### MongoDB Docker useful Command
- Pull Mongo Image: > $ docker pull mongo
- Start a mongo server instance: >  $docker run -d -p 27017:27017 --name [some-mongo-name] mongo
   -d: detach mode
   -p: Port. Format: Local Machine Port :Mongo Image Port 
- Container shell access: > $ docker exec -it [some-mongo-name] bash

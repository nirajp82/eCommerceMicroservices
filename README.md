# eCommerceMicroservices

### Mongo DB Useful Command
- Pull Mongo Image: > $ docker pull mongo
- Start a mongo server instance:  $docker run -d -p 27017:27017 --name [some-mongo-name] mongo
   -d: detach mode
   -p: Port. Format: Local Machine Port :Mongo Image Port 
- Container shell access: > $ docker exec -it [some-mongo-name] bash

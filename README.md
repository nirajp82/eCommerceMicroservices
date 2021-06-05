# eCommerceMicroservices (Reference: https://github.com/aspnetrun/run-aspnetcore-microservices)

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
   - Show a List of All Databases inside bash: > show dbs
   - Create Database: > use [databasename] -- To create/swith to db on mongo. For ex: use CatalogDB - this will create new database CalalogDB if does not exists else it will -use CatalogDB
   - for create collection > db.createCollection('[Collection_Name]') for ex: following command will create db.createCollection('Products') Product collection 
   - Insert object (record) in collection > db.Products.insertMany([{ 'Name':'Asus Laptop','Category':'Computers', 'Summary':'Summary', 'Description':'Description', 'ImageFile':'ImageFile', 'Price':54.93 }, { 'Name':'HP Laptop','Category':'Computers', 'Summary':'Summary', 'Description':'Description', 'ImageFile':'ImageFile', 'Price':88.93 } ])
   - To view objects in collection: > db.Products.find({}).pretty()

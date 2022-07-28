# Scheduling (.NET)
This Scheduling illustrates different development principles and practices such as Clean Architecture with Use Case Driven in .NET

## Getting Started

### Prerequisities
The following dependencies needs to be installed to run the application:
* [docker](https://www.docker.com/get-started)
* [docker-compose](https://www.docker.com/get-started)

### Start up
After a clone of the repo, set up the services on your local machine by running the following commands on your terminal. This command builds the application and spins up both the database and the API on the container 
```bash
 docker-compose build
 docker-compose up
```

Ensure that the services are up and running after the spin up is done. Run ``docker ps`` to get a lists of all the running services in their listening ports.

Health check of the API runs on the url ``curl -v http://localhost:5501/health``. You can also interact with the APIs by running the url below on the browser.
```
http://localhost:5501/swagger/index.html
```
To tear (or shut down) the running service in the container, run the following command on your terminal
```
docker-compose down
```

### Development
Running the application from the source code requires the folowing dependencies 
* [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* [MySQL](https://www.mysql.com/downloads/)

### Best Practices 
* [Truck Based Development](https://trunkbaseddevelopment.com/) 
* [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
* [Unit Testing](https://martinfowler.com/bliki/UnitTest.html)
* [TellDontAsk](https://martinfowler.com/bliki/TellDontAsk.html)
* [Domain Driven Design](https://martinfowler.com/bliki/DomainDrivenDesign.html)


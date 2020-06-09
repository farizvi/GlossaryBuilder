# Glossary Builder
Glossary Builder is a web application which maintains a list of words and their description.

## Project Overview
This application consists of following projects

### GlossaryBuilder.Domain
This project consists of Domain entities for the application.

### GlossaryBuilder.Infrastructure
This project consists of helper libraries and the database migration logic for the application.

### GlossaryBuilder.Application
This project consists of the actual implementation logic of the application. This project communicates with other layers of the application to perform CRUD operations

### GlossaryBuilder.WebUI
This project is the entry point of this application. It consists of the Web API methods which allow the user to perform CRUD operations

#### GlossaryBuilder.WebUI/ClientApp
This is the client application which provides the UI for Glossary Builder.

### GlossaryBuilder.IntegrationTests
This project consists of integration tests for this application. The tests are run against a separate database to test the underlying logic.

## Running the Glossary Builder Application
This application is developed using .Net Core 3.1 and Angular 9. To run this application
- Install [.Net Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)

- Install the latest version of [Node.js](https://nodejs.org/en/download/)

- In command line navigate to `src` directory and execute following command
```
dotnet restore
```

- For client app, navigate to `src\GlossaryBuilder.WebUI\ClientApp` directory in command line and execute following command
```
npm  install
```

- Navigate to `src\GlossaryBuilder.WebUI` directory from command line and run following command
```
dotnet run
```

Both Web API and Client Application will be running and you can browse the client application using following url

https://localhost:5001/

## Running the Integration Tests
To run the integration tests for this application, navigate to `tests\Application.IntegrationTests` directory from command line and execute following command
```
dotnet test
```

## Running the Unit Tests
To run the integration tests for this application, navigate to `tests\Application.UnitTests` directory from command line and execute following command
```
dotnet test
```

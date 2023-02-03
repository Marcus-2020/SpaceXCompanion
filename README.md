# SpaceXCompanion
A minimal API that consumes the SpaceXData public API over launches, rockets, crews and other data about SpaceX launches.

## Run the project

To run this project just open it in Visual Studio 2022, Rider and click to run. 

If you are using VS Code use the following command in the terminal: `dotnet run` in the API folder. 
In the case of ocurring any erros first verify if you have .NET 6 Runtime/SDK installed.
To run with hot reload in VS Code type this command in the terminal: `dotnet watch run`.

## Routes
This project has only GET routes for now, I plan to use it in an web and mobile project to show launches, rockets and crew members.

The routes working rigth now are:

- **GET**, `api/launches`: Return all launches from SpaceX;
- **GET**, `api/launches/{id}`: Return one launch from SpaceX by the informed ID;
- **GET**, `api/launches/options/{option}`: Return one or more launches from SpaceX by the option informed as a parameter. Valid options are "past", "latest" or "next";
- **GET**, `api/landpad`: Return all landpad from SpaceX launches;
- **GET**, `api/landpad/{id}`: Return one landpad from SpaceX launches by the informed ID;
- **GET**, `api/rockets`: Return all rockets from SpaceX;
- **GET**, `api/rockets/{id}`: Return one rocket from SpaceX by the informed ID;
- **GET**, `api/crew`: Return all crew members from SpaceX launches;
- **GET**, `api/crew/{id}`: Return crew member from SpaceX launches by the informed ID;
- **GET**, `api/core`: Return all cores from SpaceX launches;
- **GET**, `api/core/{id}`: Return one core from SpaceX launches by the informed ID;

## Technologies used
To build this project I used:

- .NET 6 minimal API setup;
- .NET Core HttpClient and IHttpClientFactory;
- Newtonsoft.Json for JSON serialization and deserialization;

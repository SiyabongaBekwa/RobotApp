# RobotApp
# My ASP.NET Core 6 API

Welcome to the documentation for My ASP.NET Core 6 RobotApp API.
The API facilitates:

Adding survivors with essential details like name, age, gender, ID, last location, and inventory resources (Water, Food, Medication, Ammunition).
Updating survivor location with latitude/longitude.
Flagging survivors as infected based on reports from at least three other survivors.
Connecting to the Robot CPU system for displaying Flying and land robots' locations. Additionally, it provides reports on infected and non-infected survivors' percentages, along with lists of infected survivors, non-infected survivors, and robots..

## Table of Contents
- [Getting Started](#getting-started)
- [Endpoints](#endpoints)



## Getting Started

1. Clone the repository using Visual Studio 2022.

2. Install all dependencies using `dotnet restore`.
     --Ensure that these are dependencies that are installed: `Versions for all these dependencies should be 6.00 to ensure smooth operations`
         ---AutoMapper.Extensions.Microsoft.DependencyInjection  (by Jimmy Bogard)
         ---Microsoft.EntityFrameworkCore (by Microsoft)
         ---Microsoft.EntityFrameworkCore.Design (by Microsoft)
         ---Microsoft.EntityFrameworkCore.SqlServer (by Microsoft)
         ---Microsoft.EntityFrameworkCore.Tools (by Microsoft)

3. For the database, ---Microsoft.EntityFrameworkCore.SqlServer (by Microsoft)--- this dependencies will be used,
   which will allow us to run a database locally in Visual Studio 2022.

4. Before Running the application first add a migration using this command `add-migration -context DataContext -o Data/Migrations Initial`
   Then Update you database using this command `update-database -context DataContext`or just `update-database`   

5. Now Run the application using `RobotApp` green-play button on your Visual Studio 2022.

6. The API will be accessible automatically using Swagger UI at `https://localhost:7256/swagger/index.html`.


## Endpoints

### /api/Robot

- `POST` /api/Robot/add-robot   :   Creates a new robot.
- `GET`/api/Robot/get-robots   :   Retrieves all robots.
- `GET` /api/Robot/get-robot/{Model}   :   Retrieves an existing robot using the Model of the Robot.

### /api/Survivor

- `POST` /api/Survivor/add-survivor   :   Creates a new Survivor.
- `GET`/api/Survivor/get-survivors    :   Retrieves all Survivors.
- `GET` /api/Survivor/get-survivor/{IDNumber}   :   Retrieves an existing Survivor using the IDNumber of the Survivor.
- `PUT`/api/Survivor/update-survivor    :   Updates the Coordinates based on the LastLocation of a particular Survivor.

- `POST`/api/Survivor/report-infection    :   Report a Survivor if they were exposed to contamination. Using the IDNumber of Both the Reporting and Reported Survivor.
                                                ReportedIDNumber id for the Survivor who is being reported for contamination. Once a survivor has been reported more than 3 time that survivor will be Flagged as infected

- `GET`/api/Survivor/statistics    :   Retrieves all Statistics involving Survivors. Percentage of both infected and non-Infected survivors
                                        List of both infected and non-Infected survivors


#### Parameters

- `IDNumber`: (Is required for PUT and Get) The IDNumber of the survivor is required when testing these Endpoints: 
                `GET` /api/Survivor/get-survivor/{IDNumber}
                `PUT`/api/Survivor/update-survivor


#### Response

- `200 OK`: Returns the requested resource(s).


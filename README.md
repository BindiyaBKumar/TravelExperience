# TravelExperience
This is a simple .Net Core Web API application which helps to create a new Travel Experience

# Database choice and rationale
This application uses SQL Server database in the backend. TSQL Server was chosen because of its strong support with .Net framework. SSMS provides user friendly tools to interact with the database. Since the application uses relational data (Trips/Activities) SQL Server seemed to be a good choice to support with queries, indexing, as well as transactions. Additionally, entity framework made it easy to connect and interact with SQL Server database.

The database is designed to have 2 databases - One of Trips and other for Activities. The Activity table is connected to Trips table via a foreign key relationship. An index has been placed on Activity table to make fetched based on tripID easier.


# Key design decisions
1. Chose layered architecture by seperating the service layer and data access layer. This ensures seperation of concerns for better maintainance of code.
2. Chose Data Transfer Objects (DTOs) to handle user data and response data. This ensures that the internal model data are kept seperate and not exposed.
3. Chose to implement repository pattern with repository interfaces to ensure abstraction of data access layer from service layer.


# How to run the code
1. Create Tables in your database using the below SQL Queries (provided after step 9).
2. Clone the code in your local system.
3. Open the "TravelExperienceCoreAPI.sln" file using Visual Studio/Visual Studio Code .
4. In the appsettings.json file, enter the connection string to your database under "TravelConnection".
5. In the TravelExperienceCOreAPI.http file, check the host address and change it if needed.
6. Build the application.
7. You may access the Web API URL using swagger URL on the web browser : "http://localhost:5173/swagger/" or using API URL "http://localhost:5173/api/trips" via Postman.
8. You can use the below test input data to test the POST API.

{
  "title": "Summer Vacation",
  "user": "TestUser",
  "startDate": "2025-06-10",
  "endDate": "2025-06-25",
  "activities": [
    {
      "destinationId": "Brazil",
      "duration": 1,
      "cost": 100
    },
    {
      "destinationId": "Egypt",
      "duration": 1,
      "cost": 200
    }
  ]
}

9. You may use the below invalid input to test the error validation

{
  "title": "",
  "user": "",
  "startDate": "2025-12-16",
  "endDate": "2025-12-14",
  "activities": [
    {
      "destinationId": "",
      "duration": 0,
      "cost": 0
    }
  ]
}

# SQL QUERIES
CREATE TABLE Trips(
TripId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
UserId NVARCHAR(50) NOT NULL,
Title NVARCHAR(100) NOT NULL,
StartDate DATETIME NOT NULL,
EndDate DATETIME NOT NULL,
TotalCost DECIMAL(18,2)
)

CREATE TABLE Activities(
ActivityId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
DestinationId NVARCHAR(100) NOT NULL,
Duration INT NOT NULL,
Cost DECIMAL(18,2) NOT NULL,
TripId INT NOT NULL
)



ALTER TABLE Activities
ADD CONSTRAINT FK_Trip_Activities
FOREIGN KEY (TripId)
REFERENCES Trips(TripId)
ON DELETE CASCADE;

CREATE INDEX IX_Trip_Activities
ON Activities (TripId);


# Assumptions
1. A single trip can have one or more activities associated with it.
2. Every activity would be associated with an individual trip.
3. The user would provide a minimum of 1 activity data along with its cost via the input request.
4. All fields in the input JSON are mandatory (This is validated by the code).
5. The input JSON contains the necessary user data - No authentication is implemented.






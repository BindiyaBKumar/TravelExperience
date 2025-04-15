# TravelExperience
This is a simple .Net Core Web API application which helps to create a new Travel Experience

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


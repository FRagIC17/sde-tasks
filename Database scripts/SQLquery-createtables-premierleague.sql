CREATE DATABASE PremierLeague
GO


USE PremierLeague
GO

CREATE TABLE Coaches
(
	coach_id INT IDENTITY (1,1) PRIMARY KEY,
	coach_firstname VARCHAR (100) NOT NULL,
	coach_lastname VARCHAR (100) NOT NULL
);

CREATE TABLE teams 
(
	team_id INT IDENTITY (1,1) PRIMARY KEY,
	team_name VARCHAR (50) NOT NULL,
	team_networth INT,
	team_coach_id INT NOT NULL,
	FOREIGN KEY (team_coach_id) REFERENCES Coaches (coach_id)
);

CREATE TABLE Placement 
(
	placement_id INT IDENTITY (1,1) PRIMARY KEY,
	placement_name VARCHAR (100)
);

CREATE TABLE players 
(
	player_id INT IDENTITY (1,1) PRIMARY KEY,
	player_firstname VARCHAR (100) NOT NULL,
	player_lastname VARCHAR (100) NOT NULL,
	player_networth INT,
	player_number INT, 
	player_placement_id INT NOT NULL,
	player_team_id INT,
	FOREIGN KEY (player_placement_id) REFERENCES Placement (placement_id),
	FOREIGN KEY (player_team_id) REFERENCES Teams (team_id)
);


DROP TABLE sponsors;
CREATE TABLE sponsors
(
	sponsor_id INT IDENTITY (1,1) PRIMARY KEY,
	sponsor_name VARCHAR (255),
	sponsor_sponsorship INT,
	sponsor_team_id INT,
	FOREIGN KEY (sponsor_team_id) REFERENCES Teams (team_id)
);
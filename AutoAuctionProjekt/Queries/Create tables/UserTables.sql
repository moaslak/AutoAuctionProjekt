﻿use [mort40f43.SKOLE]
CREATE TABLE Users(
ID INT IDENTITY(1,1),
Password VARCHAR(64) NOT NULL,
PRIMARY KEY(ID)
)

CREATE TABLE PrivateUser(
ID INT IDENTITY(1,1),
UserID INT FOREIGN KEY REFERENCES Users(ID),
CPRNumber VARCHAR(10) NOT NULL,
PRIMARY KEY(ID))

CREATE TABLE CorporateUser(
ID INT IDENTITY(1,1),
UserID INT FOREIGN KEY REFERENCES Users(ID),
CVRNumber VARCHAR(12) NOT NULL,
Credit MONEY,
PRIMARY KEY(ID)
)
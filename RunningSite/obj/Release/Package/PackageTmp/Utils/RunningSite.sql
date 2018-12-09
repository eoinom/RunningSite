CREATE DATABASE RunningSite

USE RunningSite

USE DingleRunningFestivalDb

--***CREATE Account TABLE***

CREATE PROC dbo.usp_Create_Account
AS
CREATE TABLE Account
(Email VARCHAR(50) NOT NULL,
Pass VARCHAR(20),
FirstName VARCHAR(20),
LastName VARCHAR(20),
Country VARCHAR(20),
Gender VARCHAR(20),
DOB DATE,
NewsletterSub bit
CONSTRAINT pkEmail PRIMARY KEY(Email)
)
GO
EXEC dbo.usp_Create_Account

--***CREATE TABLE ORDERS***

CREATE PROC usp_Create_Orders
AS
CREATE TABLE Orders
(OrderNo int IDENTITY(1,1) NOT NULL,
OrderDate DATE,
TotalAmount DECIMAL(6,2),
Address1 VARCHAR(50),
Address2 VARCHAR(50),
City VARCHAR(50),
Country VARCHAR(50),
PostalCode VARCHAR(20),
TShirtSize VARCHAR(20),
Mobile VARCHAR(20),
EmergencyContactName VARCHAR(20),
EmergencyContactNumber VARCHAR(20),
MedicalDetails VARCHAR(20),
RaceId VARCHAR(5),
AgreeRaceDisclaimer BIT,
AgreeTermsAndConditions BIT,
OrderMedalInser BIT,
StartGroup VARCHAR(20),
BibNo INT,
CC_Type VARCHAR(20),
CC_Number VARCHAR(20),
CC_Holder_FirsName VARCHAR(20) ,
CC_Holder_LastName VARCHAR(20),
CC_ExpDate_Month VARCHAR(20),
CC_ExpDate_Year VARCHAR(20),
CC_SecCode VARCHAR(3),
CONSTRAINT pkOrderNo PRIMARY KEY(OrderNo),
)
GO
EXEC usp_Create_Orders

--***CREATE RACE TABLE***

CREATE PROC usp_Create_Race
AS
CREATE TABLE Race
(RaceId VARCHAR(5) NOT NULL,
RaceDate DATE,
RaceLimit INT,
Price DECIMAL(6,2),
CONSTRAINT pkRaceId PRIMARY KEY(RaceID)
)
GO
EXEC usp_Create_Race

--***CREATE RESULTS TABLE***

CREATE PROC usp_Create_Results
AS
CREATE TABLE Results
(RaceId VARCHAR(5) NOT NULL,
BibNo int NOT NULL,
FinishPlace INT,
FinishTime VARCHAR(10),
ChipTime VARCHAR(10),

CONSTRAINT pkBibRaceId PRIMARY KEY(BibNo, RaceId),
)

GO
EXEC usp_Create_Results



--***ENTER ACCOUNT DETAILS***

CREATE PROC usp_EnterAccountDetails
@Email VARCHAR(50),
@Pass VARCHAR(20),
@FirstName VARCHAR(20),
@LastName VARCHAR(20),
@Country VARCHAR(20),
@Gender VARCHAR(20),
@DOB DATE,
@NewsletterSub BIT
AS
INSERT INTO Account VALUES
(@Email, @Pass, @FirstName, @LastName, @Country, @Gender, @DOB, @NewsletterSub)
GO





Create Table Customer
(
Id int  IDENTITY(1, 1) NOT NULL primary key,
Name nvarchar(100) NULL,
PanNumber nvarchar(100) NULL,
City nvarchar(100) NULL,
PhoneNumebr nvarchar(100) NULL,
EmailId nvarchar(100) NULL,
Company nvarchar(100) NULL,
GSTNumber nvarchar(100) NULL
)
GO
Create Table Staff
(
Id int  IDENTITY(1, 1) NOT NULL primary key,
Name nvarchar(100) NULL,
Password nvarchar(100) NULL
)
GO
Create Table Box
(
Id int  IDENTITY(1, 1) NOT NULL primary key,
Name nvarchar(100) NULL,
CreatedOn datetime NULL,
FK_StaffId int NULL
)
GO
Create Table Slot
(
Id int  IDENTITY(1, 1) NOT NULL primary key,
Name nvarchar(100) NULL,
FK_BoxId int NULL,
FK_StaffId int NULL,
FK_CustomerId int NULL,
InStatus int NULL,
OccupaidStatus int NULL
)
GO
Create Table Transactions
(
Id int  IDENTITY(1, 1) NOT NULL primary key,
FK_Customer int NULL,
FK_Slot int NULL,
FK_Staff int NULL,
Date datetime NULL,
Status nvarchar(100) NULL,
Remarks nvarchar(500) NULL
)
GO
Alter Table Transactions ADD CONSTRAINT Transactions_Customer_Id
FOREIGN KEY (FK_Customer) REFERENCES Customer (Id)
GO
Alter Table Transactions ADD CONSTRAINT Transaction_Slot_Id
FOREIGN KEY (FK_Slot) REFERENCES Slot (Id)
GO
Alter Table Transactions ADD CONSTRAINT Transactions_Staff_Id
FOREIGN KEY (FK_Staff) REFERENCES Staff (Id)
GO
Alter Table Slot ADD CONSTRAINT Slot_Box_Id
FOREIGN KEY (FK_BoxId) REFERENCES Box (Id)
GO
Alter Table Slot ADD CONSTRAINT Slot_Staff_Id
FOREIGN KEY (FK_StaffId) REFERENCES Staff (Id)
GO
Alter Table Slot ADD CONSTRAINT Slot_Customer_Id
FOREIGN KEY (FK_CustomerId) REFERENCES Customer (Id)
GO
Alter Table Box ADD CONSTRAINT Box_Staff_Id
FOREIGN KEY (FK_StaffId) REFERENCES Staff (Id)
GO

Create Table Customer
(
Id int  IDENTITY(1, 1) NOT NULL primary key,
Name nvarchar(100) NULL,
PanNumber nvarchar(100) NULL,
City nvarchar(100) NULL,
PhoneNumebr nvarchar(100) NULL,
EmailId nvarchar(100) NULL,
Company nvarchar(100) NULL,
Careof nvarchar(100) NULL,
Fk_StaffId int null,
IsExpaired bit null
)
GO
Create Table Staff
(
Id int  IDENTITY(1, 1) NOT NULL primary key,
Name nvarchar(100) NULL,
Password nvarchar (20) NULL
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
InStatus bit NULL,
OccupaidStatus bit NULL
)
GO
Alter Table Customer ADD CONSTRAINT Customer_Staff_Id
FOREIGN KEY (Fk_StaffId) REFERENCES Staff (Id)
GO
Alter Table Slot ADD CONSTRAINT Slot_Box_Id
FOREIGN KEY (FK_BoxId) REFERENCES Box (Id)
GO

Alter Table Slot ADD CONSTRAINT Slot_Staff_Id
FOREIGN KEY (FK_StaffId) REFERENCES Staff (Id)
GO
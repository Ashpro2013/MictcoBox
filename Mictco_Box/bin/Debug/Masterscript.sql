
Create Table Customer
(
Id int  IDENTITY(1, 1) NOT NULL primary key,
Name nvarchar(100) NULL,
PanNumber nvarchar(100) NULL,
Company nvarchar(100) NULL,
Careof nvarchar(100) NULL,
Password nvarchar(100) NULL,
isExpaired bit null,
FK_StaffId int null,
Fk_SlotId int null
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
InStatus bit NULL,
OccupaidStatus bit NULL
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

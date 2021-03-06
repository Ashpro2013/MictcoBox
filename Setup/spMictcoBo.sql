 IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetCustomerReport')
 DROP PROCEDURE spGetCustomerReport
GO 
Create Procedure spGetCustomerReport
(
@sText nvarchar(50) null
)
 AS 
 BEGIN 
 Select cs.Id,cs.Name,PanNumber,Company,Careof,isExpaired,sf.Name as Staffname
 From Customer cs
 inner join Staff sf on Fk_StaffId = sf.Id
 where PanNumber like '%'+ @sText + '%' or cs.Name like '%'+ @sText + '%' or cs.Company 
 like '%'+ @sText + '%' or cs.Careof like '%'+ @sText + '%'
 END 
 GO
 IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetTransactionReport')
 DROP PROCEDURE spGetTransactionReport
GO 
create Procedure spGetTransactionReport
(
@sText nvarchar(50) null
)
As
begin
select row_number() over(order by ts.Id) as SL, Date,Status,Remarks,cs.Name as CustomerName, st.Name as StaffName, sl.Name as SlotName
From Transactions ts
inner join Customer cs on FK_Customer=cs.Id
LEFT join Staff st on ts.FK_Staff = st.Id
LEFT join Slot sl  on ts.FK_Slot = sl.Id
where PanNumber like '%'+ @sText + '%' or cs.Name like '%'+ @sText + '%' or cs.Company 
 like '%'+ @sText + '%' or cs.Careof like '%'+ @sText + '%'
end
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetTransactionForMainReport')
 DROP PROCEDURE spGetTransactionForMainReport
GO 
create Procedure spGetTransactionForMainReport
(
@Val int null
)
As
begin
select row_number() over(order by ts.Id) as SL, Date,Status,Remarks,cs.Name as CustomerName, st.Name as StaffName, sl.Name as SlotName
From Transactions ts
inner join Customer cs on FK_Customer=cs.Id
LEFT join Staff st on ts.FK_Staff = st.Id
LEFT join Slot sl  on ts.FK_Slot = sl.Id
where cs.Id = @Val
end
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetMainCusomers')
 DROP PROCEDURE spGetMainCusomers
GO 
create Procedure spGetMainCusomers
(
@sText nvarchar(50) null
)
 AS 
 BEGIN 
 Select * From Customer cs
 where PanNumber like '%'+ @sText + '%' or cs.Name like '%'+ @sText + '%' or cs.Company 
 like '%'+ @sText + '%' or cs.Careof like '%'+ @sText + '%'
 END 
 GO
  IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetBox')
 DROP PROCEDURE spGetBox
GO 
Create Procedure spGetBox

 AS 
 BEGIN 

 Select *  from Box

 
 END 
GO 
 IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetCustomer')
 DROP PROCEDURE spGetCustomer
GO 
Create Procedure spGetCustomer

 AS 
 BEGIN 

 Select *  from Customer

 
 END 
GO 
 IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetSlot')
 DROP PROCEDURE spGetSlot
GO 
Create Procedure spGetSlot

 AS 
 BEGIN 

 Select *  from Slot

 
 END 
GO 
 IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetStaff')
 DROP PROCEDURE spGetStaff
GO 
Create Procedure spGetStaff

 AS 
 BEGIN 

 Select *  from Staff

 
 END 
GO 
 IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'spGetTransactions')
 DROP PROCEDURE spGetTransactions
GO 
Create Procedure spGetTransactions

 AS 
 BEGIN 

 Select *  from Transactions

 
 END 
GO 



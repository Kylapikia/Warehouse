/*
Created		20/08/2018
Modified		8/10/2018
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2005 
*/
drop table [Users];
drop table [Purchase];
drop table [Items];
drop table [House];
drop table [Investor];
drop table [Property];
drop table [Customer];
drop table [HouseTransactionLog]
drop table [ItemTransactionLog]

Create table [Customer]
(
	[CustomerID] Integer NOT NULL IDENTITY,
	[CustomerName] Char(100) NOT NULL,
	[PhoneNumber] Integer NULL,
	[Address] Varchar(50) NULL,
Primary Key ([CustomerID])
) 
go

Create table [House]
(
	[HouseId] Integer NOT NULL IDENTITY,
	[InvestorID] Integer NOT NULL,
	[PropertyAddress] Varchar(20) NULL,
	[Status] Varchar(5) NOT NULL,
	[PropertyPrice] Decimal(18,2) NULL,
Primary Key ([HouseId])
) 
go
Create table [Property]
(
	[PropertyId] Integer NOT NULL IDENTITY,
	[Name] Varchar(30) NOT NULL,
	[PropertyAddress] Varchar(20) NULL,
Primary Key ([PropertyId])
) 
go

Create table [Investor]
(
	[InvestorID] Integer NOT NULL IDENTITY,
	[InvestorName] Varchar(20) NOT NULL,
	[InvestorPhoneNumber] Varchar(30) NOT NULL,
	[InvestorEmail] Varchar(100) NULL,
	[InvestorDateOfBirth] Datetime NULL,
	[InvestorAddress] Varchar(30) NULL,
Primary Key ([InvestorID])
) 
go

Create table [Users]
(
	[UserID] Integer NOT NULL IDENTITY, UNIQUE ([UserID]),
	[Username] Varchar(50) NOT NULL,
	[Password] Varchar(50) NOT NULL,
	[Level] Varchar(15) NOT NULL,
Primary Key ([UserID])
) 
go

Create table [Items]
(
	[ItemID] Integer NOT NULL IDENTITY,
	[PropertyId] Integer NULL,
	[ItemName] Varchar(50) NOT NULL,
	[Price] Decimal(18,2) NOT NULL,
	[Location] Char(1) NULL,
	[Quantity] Integer NULL,
Primary Key ([ItemID])
) 
go

Create table [Purchase]
(
	[PurchaseID] Integer NOT NULL IDENTITY, UNIQUE ([PurchaseID]),
	[CustomerID] Integer NOT NULL,
	[ItemID] Integer NOT NULL,
	[PurchaseDate] Datetime NULL,
	[Quantity] Integer NULL,
Primary Key ([PurchaseID])
) 
go

Create table [HouseTransactionLog]
(
	[HouseTransactionID] Integer NOT NULL IDENTITY,
	[TransactionDate] Datetime NOT NULL,
	[Action] Varchar(40) NOT NULL,
	[Type] Varchar(20) NOT NULL,
	[Data] Varchar(200) NOT NULL,
Primary Key ([HouseTransactionID])
) 
go

Create table [ItemTransactionLog]
(
	[ItemTransactionID] Integer NOT NULL IDENTITY,
	[TransactionDate] Datetime NOT NULL,
	[Action] Varchar(40) NOT NULL,
	[Type] Varchar(20) NOT NULL,
	[Data] Varchar(200) NOT NULL,
Primary Key ([ItemTransactionID])
) 
go

Alter table [Purchase] add  foreign key([CustomerID]) references [Customer] ([CustomerID])  on update no action on delete no action 
go
Alter table [Items] add  foreign key([PropertyId]) references [Property] ([PropertyId])  on update no action on delete no action 
go
Alter table [House] add  foreign key([InvestorID]) references [Investor] ([InvestorID])  on update no action on delete no action 
go
Alter table [Purchase] add  foreign key([ItemID]) references [Items] ([ItemID])  on update no action on delete no action 
go


Set quoted_identifier on
go


Set quoted_identifier off
go
/*
drop table [Users];
drop table [Purchase];
drop table [Items];
drop table [House];
drop table [Investor];
drop table [Property];
drop table [Customer];

Properties:
At the moment there is only 1 warehouse, supplier and store
1 = Supplier (S)
2 = Warehouse (W)
3 = Rental Store (R)
4 = Renovation (H)
*/

insert into Customer values('Pam',02102,'10 Yat Street')

insert into Investor values('Pam',02102,'pam@hotmail.com','10.10.97','10 Yat Street')
insert into Investor values('Kyla',02111,'kyla@hotmail.com','11.10.97','11 Cold Road')
insert into Investor values('Rose',03402,'rose@hotmail.com','10.04.96','66 King Street')
insert into Investor values('Debby',05552,'debby@hotmail.com','12.07.98','12 FoodQueen Road')

insert into Property values('Supplier','Esk Street')
insert into Property values('Warehouse','Don Street')
insert into Property values('Rental Store','Dee Street')
insert into Property values('Renovation','Queens Street')

insert into Items values(1,'Cloth',20,'W',2)
insert into Items values(2,'Window',30,'R',3)
insert into Items values(3,'Door',40,'S',6)
insert into Items values(4,'Mops',50,'W',9)

insert into House values(1,'43 Tay Street','B',900000)

insert into Users values('Kyla','ZsnPcNsupYl5oiTmGNUL2g==','Admin');
insert into Users values('Rose','/Nx7QgdmChNy0M1Uka2Fbg==','Employee');
insert into Users values('Pam','kcD3EAvecZxEeQ5991ehpg==','Investor');


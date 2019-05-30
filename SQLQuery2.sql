select * from Customer
select * from Investor
select * from TransactionLog
ALTER TABLE Investor ALTER COLUMN InvestorDateOfBirth date not null
ALTER TABLE TransactionLog ALTER COLUMN TransactionDate date not null

Create procedure spInsertDeletedIntoTBLCustomer
@CustomerID int, 

SET IDENTITY_INSERT Customer ON

insert into Customer (CustomerID,CustomerName,PhoneNumber,Address) values (3,'Rose','0204639999','99A Conon street')

SET IDENTITY_INSERT Customer OFF
GO
select * from Purchase

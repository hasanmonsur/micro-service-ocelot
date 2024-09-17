CREATE DATABASE SalesManagement;

USE SalesManagement;

CREATE TABLE Orders
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(100),
    TotalAmount DECIMAL(18,2),
    OrderDate DATETIME
);

CREATE TABLE Products
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Price DECIMAL(18,2)
);


CREATE TABLE Customers
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(100),
    CustomerAddress NVARCHAR(100)
);

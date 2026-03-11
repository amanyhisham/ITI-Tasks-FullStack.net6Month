--Q1-Part2-Lap5-----
select SalesOrderID,ShipDate 
from Sales.SalesOrderHeader 
where OrderDate between '7/28/2002' and '7/29/2014'
--Q2-Part2-Lap5-----
select productID,Name
from Production.Product
where StandardCost <110.00
--Q3-Part2-Lap5-----
select productID,Name
from Production.Product
where  Weight is Null

---Differennce Bettween Q3&Q2------
select COUNT(*) as[StandardCost]
from Production.Product
where StandardCost <110.00

SELECT COUNT(*) AS [Weight]
FROM Production.Product
WHERE Weight IS NULL
----------------------------------------
--Q4-Part2-Lap5-----
SELECT  Color,Name as[Name Product]
FROM Production.Product
WHERE Color in('Silver','Black','Red')
--Q5-Part2-Lap5-----
SELECT Name as[Name Product]
FROM Production.Product
WHERE Name like 'B%'
--Q6-Part2-Lap5-----
UPDATE Production.ProductDescription 
SET Description = 'Chromoly steel_High of defects' 
WHERE ProductDescriptionID = 3 

SELECT Description  ,ProductDescriptionID
FROM Production.ProductDescription 
WHERE Description LIKE '%\_%' ESCAPE '\'
--Q7-Part2-Lap5-----
SELECT sum(TotalDue ) AS Sum_TotalDue ,OrderDate
FROM Sales.SalesOrderHeader
WHERE OrderDate between '7/1/2001' and '7/31/2014'
group by OrderDate
order by OrderDate
--Q8-Part2-Lap5-----
SELECT DISTINCT HireDate
FROM HumanResources.Employee
ORDER BY HireDate;
--Q9-Part2-Lap5-----
SELECT AVG(Distinct(ListPrice)) AS AvgUniquePrice
FROM Production.Product

SELECT AVG((ListPrice)) AS AvgallPrice
FROM Production.Product
--Q10-Part2-Lap5-----
SELECT CONCAT('The ', Name, ' is only !', ListPrice) AS ProductInfo
from Production.Product
WHERE ListPrice BETWEEN 100 AND 120
order by ListPrice
--Q11-A-Part2-Lap5-----
create Table store_Archive0(
rowguid uniqueidentifier not null,
Name nvarchar(50) not null,
salesPersonID int null,
DEmographics  XML(Sales.StoreSurveySchemaCollection) null
);

insert into store_Archive0(rowguid,Name,salesPersonID,DEmographics)
SELECT rowguid, Name, SalesPersonID, Demographics
FROM Sales.Store;

SELECT * FROM store_Archive0;        
SELECT COUNT(*) AS TotalRows FROM store_Archive0   
---another solution----
SELECT rowguid, Name, SalesPersonID, Demographics
INTO store_Archive1
FROM Sales.Store;

SELECT * FROM store_Archive1;        
SELECT COUNT(*) AS TotalRows FROM store_Archive1 
--Q11-B-Part2-Lap5-----
CREATE TABLE store_Archive2 (
    rowguid UNIQUEIDENTIFIER,
    Name NVARCHAR(100),
    SalesPersonID INT,
    Demographics NVARCHAR(MAX)
);

SELECT * FROM store_Archive2;        
SELECT COUNT(*) AS TotalRows FROM store_Archive2;
--Q12--Part2-Lap5-----
SELECT FORMAT(GETDATE(), 'yyyy-MM-dd') AS [Data Today]
UNION
SELECT FORMAT(GETDATE(), 'dd MMMM yyyy')
UNION
SELECT FORMAT(GETDATE(), 'dd/MM/yyyy')
UNION
SELECT FORMAT(GETDATE(), 'dddd, dd MMMM yyyy')
UNION
SELECT FORMAT(GETDATE(), 'MM/dd/yyyy')
UNION
SELECT FORMAT(GETDATE(), 'yyyy.MM.dd')
UNION
SELECT FORMAT(GETDATE(), 'dd.MM.yyyy')
 
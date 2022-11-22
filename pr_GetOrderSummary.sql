USE [NORTHWND]
GO

/****** Object:  StoredProcedure [dbo].[pr_GetOrderSummary]    Script Date: 2022/11/18 19:04:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--EXEC pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=NULL , @CustomerID=NULL
--EXEC pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=5 , @CustomerID=NULL
--EXEC pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=NULL , @CustomerID='VINET'
--EXEC pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=5 , @CustomerID='VINET'



CREATE PROCEDURE [dbo].[pr_GetOrderSummary]
 @StartDate datetime, @EndDate datetime, @CustomerID nchar(5),@EmployeeID int
AS
SELECT 
	emp.TitleOfCourtesy + ' ' + emp.FirstName + ' ' + emp.LastName EmployeeFullName,
	shp.CompanyName ShipperCompanyName, 
	cust.CompanyName CustomerCompanyName,
	COUNT(ord.OrderID) NumberOfOrders,
	ord.OrderDate [Date],
	SUM(ord.Freight) TotalFreightCost,
	COUNT(DISTINCT ordD.ProductID) NumberOfDifferentProducts,
	(SUM(CONVERT(MONEY,(ordD.UnitPrice * ordD.Quantity * (1 - ordD.Discount) /100)) * 100) * COUNT(DISTINCT ordD.ProductID)) TotalOrderValue
FROM Orders ord
	INNER JOIN Customers cust ON ord.CustomerID = cust.CustomerID
	INNER JOIN Employees emp ON ord.EmployeeID = emp.EmployeeID
	INNER JOIN [Order Details] ordD ON ord.OrderID = ordD.OrderID
	INNER JOIN Shippers shp ON ord.ShipVia = shp.ShipperID
WHERE   (ord.OrderDate BETWEEN @StartDate AND @EndDate)
		AND ord.CustomerID = ISNULL((CASE @CustomerID WHEN '' THEN NULL ELSE @CustomerID END), ord.CustomerID) -- Check if no customerID was supplied, otherwise return the customer who ordered
		AND ord.EmployeeID = ISNULL((CASE @EmployeeID WHEN '' THEN NULL ELSE @EmployeeID END), ord.EmployeeID) -- Check if no employeeID was supplied, otherwise return the employee	
GROUP BY 
emp.TitleOfCourtesy, 
emp.FirstName,
emp.LastName,
cust.CompanyName, 
ord.OrderDate,
shp.CompanyName
GO


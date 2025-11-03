-- Total Sales
SELECT SUM(Amount) AS TotalSales
FROM dwh.FactSales;

-- Sales by Region
SELECT Region, SUM(Amount) AS TotalSales
FROM dwh.FactSales
GROUP BY Region
ORDER BY TotalSales DESC;

-- Top Selling Products
SELECT ProductName, SUM(Amount) AS SalesValue
FROM dwh.FactSales
GROUP BY ProductName
ORDER BY SalesValue DESC;

-- Average Ton / KG Price
SELECT 
    ProductName,
    SUM(Amount) / NULLIF(SUM(QuantityKG),0) AS PricePerKG,
    SUM(Amount) / NULLIF(SUM(QuantityTON),0) AS PricePerTon
FROM dwh.FactSales
GROUP BY ProductName;

-- Incremental Load Example
-- Source: staging.sales
-- Target: dwh.FactSales

MERGE dwh.FactSales AS TARGET
USING staging.sales AS SOURCE
ON TARGET.Date = SOURCE.Date
   AND TARGET.ProductName = SOURCE.ProductName
   AND TARGET.Region = SOURCE.Region
WHEN MATCHED THEN
    UPDATE SET 
        TARGET.Amount = SOURCE.Amount,
        TARGET.QuantityKG = SOURCE.QuantityKG,
        TARGET.QuantityTON = SOURCE.QuantityTON
WHEN NOT MATCHED THEN
    INSERT (Date, Region, ProductCategory, ProductName, CustomerType, Amount, QuantityKG, QuantityTON)
    VALUES (SOURCE.Date, SOURCE.Region, SOURCE.ProductCategory, SOURCE.ProductName, SOURCE.CustomerType, SOURCE.Amount, SOURCE.QuantityKG, SOURCE.QuantityTON);

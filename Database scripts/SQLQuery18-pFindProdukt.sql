ALTER PROCEDURE pFindProdukt 
    @brand_id INT
AS
SELECT 
    p.product_name, 
    p.list_price, 
    b.brand_name
FROM production.brands b
INNER JOIN production.products p 
    ON p.brand_id = b.brand_id
WHERE b.brand_id = @brand_id;
GO

EXEC pFindProdukt @brand_id = 6;

SELECT * FROM production.brands;

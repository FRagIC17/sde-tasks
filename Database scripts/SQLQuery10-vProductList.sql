CREATE VIEW vProductList AS
SELECT 
	p.product_name,
	p.list_price,
	b.brand_name,
	s.quantity
FROM production.products p
JOIN production.brands b
	ON p.brand_id = b.brand_id
JOIN production.stocks s
	ON p.product_id = s.product_id;

SELECT * FROM vProductList;
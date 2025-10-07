CREATE TRIGGER AutomatiskOpdateringAfProduktPris
ON production.products
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Opdater ordrelinjer, hvis list_price er ændret
    UPDATE oi
    SET oi.list_price = i.list_price
    FROM sales.order_items AS oi
    INNER JOIN inserted AS i 
        ON oi.product_id = i.product_id
    INNER JOIN deleted AS d 
        ON d.product_id = i.product_id
    WHERE i.list_price <> d.list_price; -- Kun når prisen reelt er ændret
END;

	
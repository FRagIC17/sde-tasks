--at kunne orientere alle kunder alphabetisk
SELECT * FROM sales.customers ORDER BY first_name;

--opdaterer kunde nr. 600 p� deres adresse 
UPDATE sales.customers 
SET street='57 highway'
WHERE customer_id=600;
SELECT * FROM sales.customers WHERE customer_id=600;

--finde Pamelias ordre og slette dem fuldst�ndig fra databasen
SELECT * FROM sales.customers WHERE first_name='Pamelia' AND last_name='Newman';
DELETE FROM sales.orders WHERE customer_id=10;
--bruger select til at tjekke om �ndringen faktisk er sket og korrekt
SELECT * FROM sales.orders ORDER BY customer_id;
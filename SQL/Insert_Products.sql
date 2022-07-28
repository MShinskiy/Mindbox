
INSERT INTO Products (_name, cat_id) VALUES 
('TV', (SELECT c.cat_id FROM Categories AS c WHERE c._name = 'Electronics') ),
('Laptop', (SELECT c.cat_id FROM Categories AS c WHERE c._name = 'Electronics') ),
('T-Shirt', (SELECT c.cat_id FROM Categories AS c WHERE c._name = 'Clothes') ),
('House', null );

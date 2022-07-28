SELECT c._name AS Category_name, p._name AS Product_name
FROM Products AS p
LEFT JOIN Categories AS c ON c.cat_id=p.cat_id
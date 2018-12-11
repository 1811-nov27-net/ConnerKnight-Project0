
INSERT INTO PZ.Content(Name, Price)
VALUES ('Cheese Pizza', 10.99),
('Pepperoni Pizza', 13.99),
('Supreme Pizza', 15.99)

INSERT INTO PZ.Ingredient(Name)
VALUES ('Pepperoni'),
('Olives'),
('Sausage'),
('Bell Pepper')

INSERT INTO PZ.ContentIngredient(ContentId,IngredientId)
VALUES (2,1),
(3,2),
(3,3),
(3,4)

select * from PZ.[User]
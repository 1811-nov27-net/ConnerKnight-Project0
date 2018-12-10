
CREATE SCHEMA PZ;
GO
DROP TABLE PZ.Content

DROP TABLE PZ.[User]
DROP TABLE PZ.[Location]



CREATE TABLE PZ.[User](
	UserId		INT IDENTITY(1,1),
	FirstName	NVARCHAR(100),
	LastName	NVARCHAR(100),
	CONSTRAINT	PK_User PRIMARY KEY (UserId)
);

--select * from PZ.[User]

CREATE TABLE PZ.[Location](
	LocationId	INT IDENTITY(1,1),
	Name		NVARCHAR(100),
	CONSTRAINT	PK_Location PRIMARY KEY (LocationId)
);

CREATE TABLE PZ.Content(
	ContentId	INT	IDENTITY(1,1),
	Name		NVARCHAR(100),
	Price		MONEY,
	CONSTRAINT PK_Content PRIMARY KEY (ContentId)
);

CREATE TABLE PZ.[Order](
	OrderId		INT IDENTITY(1,1),
	LocationId	INT,
	UserId		INT,
	CONSTRAINT PK_Order PRIMARY KEY (OrderId),
	CONSTRAINT	FK_OrderLocation FOREIGN KEY (LocationId) REFERENCES PZ.[Location](LocationId),
	CONSTRAINT	FK_OrderUser FOREIGN KEY (UserId) REFERENCES PZ.[User](UserId)
);

CREATE TABLE PZ.OrderContent(
	OrderId		INT,
	ContentId	INT,
	Amount		INT,
	CONSTRAINT PK_OrderContent PRIMARY KEY (OrderId,ContentId),
	CONSTRAINT	FK_OrderContentOrder FOREIGN KEY (OrderId) REFERENCES PZ.[Order](OrderId),
	CONSTRAINT	FK_OrderContentContent FOREIGN KEY (ContentId) REFERENCES PZ.Content(ContentId)
);

CREATE TABLE PZ.Ingredient(
	IngredientId	INT	IDENTITY(1,1),
	Name		NVARCHAR(100),
	CONSTRAINT PK_Ingredient PRIMARY KEY (IngredientId)
);

CREATE TABLE PZ.ContentIngredient(
	ContentId	INT,
	IngredientId	INT,
	CONSTRAINT PK_ContentIngredient PRIMARY KEY (ContentId,IngredientId),
	CONSTRAINT	FK_ContentIngredientContent FOREIGN KEY (ContentId) REFERENCES PZ.Content(ContentId),
	CONSTRAINT	FK_ContentIngredientIngredient FOREIGN KEY (IngredientId) REFERENCES PZ.Ingredient(IngredientId)

);

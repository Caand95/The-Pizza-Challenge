CREATE TABLE [Customer] (
  [ID_Customer] int,
  [Name] varchar(50),
  [Address] varchar(50),
  [Zip Code] varchar(4),
  [City] varchar(25),
  [Phone] varchar(8),
  PRIMARY KEY ([ID_Customer])
);

CREATE TABLE [Order] (
  [ID_Order] int,
  [ID_Customer] int,
  [Date] date,
  [Time] time,
  PRIMARY KEY ([ID_Order]),
  FOREIGN KEY ([ID_Customer])
);

CREATE TABLE [Ingrediens] (
  [ID_Ingrediens] int,
  [Name] varchar(50),
  PRIMARY KEY ([ID_Ingrediens])
);

CREATE TABLE [Item_Type] (
  [ID_Type] int,
  [Name] varchar(50),
  PRIMARY KEY ([ID_Type])
);

CREATE TABLE [Item] (
  [ID_Item] int,
  [Name] varchar(50),
  [ID_Type] tinyint,
  PRIMARY KEY ([ID_Item]),
  FOREIGN KEY ([ID_Type])
);

CREATE TABLE [Item_Ingrediens] (
  [ID_Item] int,
  [ID_Ingrediens ] int,
  FOREIGN KEY ([ID_Item]),
  FOREIGN KEY ([ID_Ingrediens]),
  PRIMARY KEY ([ID_Item], [ID_Ingrediens])
);


CREATE TABLE [Size_Price] (
  [ID_Item] int,
  [Size] char,
  [Price] decimal,
  FOREIGN KEY ([ID_Item]),
  PRIMARY KEY ([ID_Item], [Size])
);

CREATE TABLE [Order_Item] (
  [ID_Order] int,
  [ID_Item] varchar(50),
  FOREIGN KEY ([ID_Order]),
  FOREIGN KEY ([ID_Item])
  PRIMARY KEY ([ID_Order], [ID-Item])
);
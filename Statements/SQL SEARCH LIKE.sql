SELECT dbo.Item.Name, dbo.Ingrediens.Name AS Ingrediens
FROM dbo.Item 
INNER JOIN dbo.Item_Ingrediens
ON dbo.Item.ID_Item = dbo.Item_Ingrediens.ID_Item 
INNER JOIN dbo.Ingrediens
ON dbo.Ingrediens.ID_Ingrediens = dbo.Item_Ingrediens.ID_Ingrediens
WHERE 
	(dbo.Item.ID_Item IN
		(SELECT Item_1.ID_Item
		FROM
		dbo.Item AS Item_1 
		INNER JOIN dbo.Item_Ingrediens AS Item_Ingrediens_1
		ON Item_1.ID_Item = Item_Ingrediens_1.ID_Item 
		INNER JOIN dbo.Ingrediens AS Ingrediens_1 
		ON Item_Ingrediens_1.ID_Ingrediens = Ingrediens_1.ID_Ingrediens
		WHERE (Ingrediens_1.Name LIKE '%?%')
		)
	)
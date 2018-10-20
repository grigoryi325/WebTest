select 
	p.ProductID,
	p.Name,
	p.Number,
	p.Price,
	c.Value as Category
 from Products as p 
 join Category c on c.Id = p.Category
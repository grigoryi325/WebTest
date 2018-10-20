select 
	                p.ProductID,
	                p.Name,
	                p.Number,
	                p.Price,
                    c.Id as Category,
	                c.Value as CategoryName
                 from Products as p 
                 join Category c on c.Id = p.Category
				 where p.ProductID = 10
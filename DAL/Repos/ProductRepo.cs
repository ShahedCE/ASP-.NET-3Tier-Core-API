using DAL.EF;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
	public class ProductRepo
	{
		PMSContext db;
		public ProductRepo(PMSContext db)
		{
			this.db=db;
		}

		//CRUD operations
		public bool Create(Product p)
		{
			db.Products.Add(p);
	
			return db.SaveChanges() >0;

		}

		public List<Product> Get()
		{
			var data= db.Products.ToList();
			return data;
		}
		
		public Product Get(int id)
		{
			var data= db.Products.Find(id);
			return data;

		}

		public bool Update (Product p)
		{
			var ex= Get (p.Id);
			if (ex == null) 
				return false; // not found

			db.Entry(ex).CurrentValues.SetValues(p);
			return db.SaveChanges() > 0;

		}

		public bool Delete(int id)
		{
			var ex= Get(id);
			db.Products.Remove(ex);
			return db.SaveChanges() > 0;
		}
	}
}

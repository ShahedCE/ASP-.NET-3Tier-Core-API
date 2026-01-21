using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
	internal class ProductRepo : IRepository<Product>, IProductFeature
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
			if (data == null)
			{
				throw new Exception("Product not found!");
			}
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


		//Features
		public Product GetCategoryByProductId(int id)
		{
			var data= db.Products.Include(p=> p.Category).SingleOrDefault(p=>p.Id==id);
			if (data == null)
			{
				throw new Exception("Product not found!");
			}
			return data; ;
		}

		public List<Product> GetCategoryByProductName(string name)
		{
			var data= db.Products.Include(p => p.Category).Where(p => p.Name.Contains(name)).ToList();
			return data;
		}

	}
}

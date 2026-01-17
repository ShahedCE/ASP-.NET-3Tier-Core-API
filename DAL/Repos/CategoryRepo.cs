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
	internal class CategoryRepo : IRepository<Category> , ICategoryFeature
	{
		PMSContext db;

		public CategoryRepo(PMSContext db)  // Taking the configured PMSContext from DI container
		{
			this.db = db;  
		}

		public bool Create(Category c)
		{
			db.Categories.Add(c);
			return db.SaveChanges() > 0;

		}
		public List<Category> Get()
		{
			return db.Categories.Include(cat=> cat.Products).ToList();
		}

		public List<Category> GetWithProducts()
		{
			 return db.Categories.Include( cat => cat.Products).ToList();
		}
		public Category Get(int id)
		{
			var category = db.Categories.Find(id);
			return category;
		}
			public bool Update(Category c)
		{
			var ex = Get(c.Id);
			if (ex == null) return false; // not found

			db.Entry(ex).CurrentValues.SetValues(c);
			return db.SaveChanges() > 0;
		}


		public bool Delete(int id)
		{
			var ex = Get(id);
			db.Categories.Remove(ex);
			return db.SaveChanges() > 0;

		}

		public Category GetWithProducts(int id)
		{
			var prod= (from c in db.Categories.Include(cat => cat.Products)
					  where c.Id == id
					  select c).SingleOrDefault();
			return prod;
		}

		public Category FindByName(string name)
		{
			var category = (from c in db.Categories
							where c.Name.Contains(name)
							select c).SingleOrDefault();
			return category;
		}

		public Category FindByNameWitProducts(string name)
		{
			var cat = db.Categories.Include(cat=> cat.Products).SingleOrDefault(cat=> cat.Name.Contains(name));	
			return cat;	
		}

		public Category HighestProducts()
		{
			var cat= (from c in db.Categories.Include(c=>c.Products)
		 orderby  c.Products.Count descending select c).FirstOrDefault();
			return cat;


		}
	}
}

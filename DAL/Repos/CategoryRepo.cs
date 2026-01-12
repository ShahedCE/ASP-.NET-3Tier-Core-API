using DAL.EF;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
	public class CategoryRepo
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
		public List <Category> Get()
		{
			return db.Categories.ToList();
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




	}
}

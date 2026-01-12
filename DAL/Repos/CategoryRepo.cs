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


	}
}

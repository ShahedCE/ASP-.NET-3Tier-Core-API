using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public  class DataAccessFactory
	{
		PMSContext db;
		public  DataAccessFactory(PMSContext db)
		{
			this.db= db;
		}

		public IRepository<Category> CategoryData() //Return type is IRepository of Category
		{
			return new CategoryRepo(db); //Returning CategoryRepo object which implements IRepository
		}

		public IRepository<Product> ProductData()//Return type is IRepository of Product
		{
			return new ProductRepo(db); //Returning ProductRepo object which implements IRepository
		}

		public ICategoryFeature CategoryFeature()
		{
			return new CategoryRepo(db); //Returning CategoryRepo object which implements ICategoryFeature
		}
	}
}

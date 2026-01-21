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

		//Category
		public IRepository<Category> CategoryData() //Return type is IRepository of Category
		{
			return new CategoryRepo(db); //Returning CategoryRepo object which implements IRepository
		}
		public ICategoryFeature CategoryFeature()
		{
			return new CategoryRepo(db); //Returning CategoryRepo object which implements ICategoryFeature
		}

		//Product
		public IRepository<Product> ProductData()//Return type is IRepository of Product
		{
			return new ProductRepo(db); //Returning ProductRepo object which implements IRepository
		}

		public IProductFeature ProductFeature()
		{
			return new ProductRepo(db); //Returning ProductRepo object which implements IProductFeature
		}

		//Order
		public IRepository<Order> OrderData()
		{
			return new OrderRepo(db);
		}
		public IOrderFeature OrderFeature()
		{
			return new OrderRepo(db);
		}
		//OrderItem only for CRUD operations no feature needed
		public IRepository<OrderItem> OrderItemData()
		{
			return new OrderItemRepo(db);
		}

		//Payment
		public IRepository<Payment> PaymentData()
		{
			return new PaymentRepo(db);
		}
		public IPaymentFeature PaymentFeature()
		{
			return new PaymentRepo(db);
		}
	
	}
}

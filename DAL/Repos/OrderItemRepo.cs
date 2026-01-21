using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
	internal class OrderItemRepo : IRepository<OrderItem>
	{
		PMSContext db;
		public OrderItemRepo(PMSContext db)  // Taking the configured PMSContext from DI container
		{
			this.db = db;
		}
		//Only CRUD Operations, no feature needed
		public bool Create(OrderItem obj)
		{
			var res = db.OrderItems.Add(obj);
			return db.SaveChanges() > 0;
		}

		public List<OrderItem> Get()
		{
			var data = db.OrderItems.ToList();
			return data;
		}

		public OrderItem Get(int id)
		{
			var data = db.OrderItems.Find(id);
			if (data == null)
			{
				throw new Exception("Order Item not found");
			}
			return data;
		}

		public bool Update(OrderItem ord)
		{
			var ex = Get(ord.Id);
			if (ex == null) return false; // not found

			db.Entry(ex).CurrentValues.SetValues(ord);
			return db.SaveChanges() > 0;
		}

		public bool Delete(int id)
		{
			var ex = db.OrderItems.Find(id);
			if (ex == null) return false;
			db.OrderItems.Remove(ex);
			return db.SaveChanges() > 0;
		}
	}
}

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
	internal class OrderRepo: IRepository<Order>, IOrderFeature
	{
		PMSContext db;
		public OrderRepo(PMSContext db)  // Taking the configured PMSContext from DI container
		{
			this.db = db;
		}
		//Basic CRUD Operations
		public bool Create(Order obj)
		{
			var res= db.Orders.Add(obj);
			return db.SaveChanges() > 0;
		}

		public List<Order> Get()
		{
			var data= db.Orders.ToList();
			return data;
		}

		public Order Get(int id)
		{
			var data= db.Orders.Find(id);
			if(data==null)
			{
				throw new Exception("Order not found");
			}
			return data;
		}

		public bool Update(Order obj)
		{
			var ex = Get(obj.Id);
			if(ex==null) 
				return false;
			  db.Entry(ex).CurrentValues.SetValues(obj);
			return db.SaveChanges() > 0;
		}
		public bool Delete(int id)
		{
			var ex = db.Orders.Find(id);
			if(ex==null) return false;
			db.Orders.Remove(ex);
			return db.SaveChanges() > 0;
		}

		//Features
		// Get Products by Order ID
		public List<Order> GetProductsByOrderId(int oid)
		{
			var products = db.Orders //Have to map <Order> to <OrderDTO>
						   .Include(o => o.OrderItems) //have to map <OrderItemDTO> to <OrderItemProductDTO>
						   .ThenInclude(oi => oi.Product) //OrderItems have Product Details
						   .Where(o => o.Id == oid)
						   .ToList();

			return products	;
		}
		//Get Order Items for a specific Order
		public List<OrderItem> GetOrderItems(int oid)
		{
			var ordered = db.OrderItems.Include(oi => oi.Product).//Get OrderItems with Product details
						  Where(oi => oi.OrderId == oid).ToList();  //Filter by Order ID

			return ordered;
		}
		




	}
}

using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
	public interface IOrderFeature
	{
		List<Order> GetProductsByOrderId(int oid);

		List<OrderItem> GetOrderItems(int oid);




	}
}

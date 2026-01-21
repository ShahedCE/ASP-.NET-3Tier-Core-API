using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
	public class Order
	{
		public int Id { get; set; }
		public string Status { get; set; } = null!;
		public DateTime OrderDate { get; set; }

		public virtual List<OrderItem> OrderItems { get; set; }
		public Order()
		{
			OrderItems = new List<OrderItem>();
		}

		//Navigation property for one-to-one relationship with Payment
		public virtual  Payment Payment { get; set; } = null!;	



	}
}

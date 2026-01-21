using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
	public class OrderItem
	{
		public int Id { get; set; }

		// Additional Data about the order item such as quantity
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }

		//Foreign key relationship to Order
		public int OrderId { get; set; }
		public virtual Order Order { get; set; }= null!;

		//Foreign key relationship to Product
		public int ProductId { get; set; }
		public virtual Product Product { get; set; }= null!;  //Navigation property
	}
}

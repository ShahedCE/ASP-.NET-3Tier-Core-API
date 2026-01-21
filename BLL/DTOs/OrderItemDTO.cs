using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
	public class OrderItemDTO
	{
		//Only for Mapping Table OrderItems
		public int Id { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }

		//Foreign key relationship to Order
		public int OrderId { get; set; }

		//Foreign key relationship to Product
		public int ProductId { get; set; } 
	}
}

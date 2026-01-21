using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
	public class OrderProductDTO
	{

		//For Order Details One Order has many products
		//Then map to OrderItemProductDTO for product details
		public int Id { get; set; }
		public string Status { get; set; } = string.Empty;
		public DateTime OrderDate { get; set; }

		public List<OrderItemProductDTO> Products { get; set; } //One order has one or more products, we are retrieving products with order items 
					= new List<OrderItemProductDTO>(); //Initialize by empty list
	}
}

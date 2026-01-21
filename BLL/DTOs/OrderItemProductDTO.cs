using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
	public class OrderItemProductDTO
	{
			public int ProductId { get; set; }
			public string ProductName { get; set; } = string.Empty;

			public int Quantity { get; set; }
			public decimal UnitPrice { get; set; }
		

	}
}

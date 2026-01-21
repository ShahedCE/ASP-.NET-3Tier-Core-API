using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
	public class ProductDTO
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Product name is required.")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Product name must be between 2 and 100 characters.")]
		public string Name { get; set; } = null!;

		[Range(1.00, double.MaxValue, ErrorMessage = "Price must be greater than 0.99")]
		public decimal Price { get; set; }

		[Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative.")]
		public int Quantity { get; set; }

		[Required(ErrorMessage = "Category ID is required.")]
		public int CId { get; set; } // CategoryId foreign key property

	}
}

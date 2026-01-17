using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
	public class Product
	{
		public int Id { get; set; }
		[StringLength(50)]
		[Column(TypeName = "varchar")]
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int  Quantity { get; set; }

		//One to One relationship with Product to Category
		//One Product has one Category

		[ForeignKey("Category")] //Specifies that CId is a foreign key for the Category navigation property
		public int CId { get; set; } // or direct CategoryId foreign key property 

		public virtual Category Category { get; set; } //Navigation property, makes the relationship

	}
}

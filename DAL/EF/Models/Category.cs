using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
	public class Category
	{
		public int Id { get; set; }
		[StringLength(50)]
		[Column(TypeName = "varchar")]
		public string Name { get; set; }

		//One to Many
		//One Category has many Products
		public virtual List<Product> Products { get; set; } //Navigation property, makes the relationship

		//Constructor to initialize the Products list
		//Whenever taking any collection, make sure to initialize it in the constructor to avoid null reference exception
		public Category()
		{
			Products = new List<Product>();
		}
	}
}

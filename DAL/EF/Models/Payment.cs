using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
	public class Payment
	{
		public int Id { get; set; }
		public string Status { get; set; } = "Pending"; // default
		public decimal Amount { get; set; } // will be set from service 
		public string? Method { get; set; } // nullable
		public DateTime? PaymentDate { get; set; } // nullable

		// One-to-One with Order
		public int OrderId { get; set; }
		public virtual Order Order { get; set; } = null!;
	}

}

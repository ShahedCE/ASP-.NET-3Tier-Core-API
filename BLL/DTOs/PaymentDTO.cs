using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
	public class PaymentDTO
	{
		public int Id { get; set; }
		public string Status { get; set; } = "Pending";
		public decimal Amount { get; set; }
		public string? Method { get; set; }   // nullable
		public DateTime? PaymentDate { get; set; } // nullable
		public int OrderId { get; set; }
	}

}

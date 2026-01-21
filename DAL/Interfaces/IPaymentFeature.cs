using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
	public interface IPaymentFeature
	{
		
		Payment GetPaymentByOrderId(int oid);
		bool UpdatePayment(Payment payment);
		bool CreatePayment(Payment payment);
	}
}

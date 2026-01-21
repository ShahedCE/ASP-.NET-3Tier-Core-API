using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class PaymentService
	{
		DataAccessFactory factory;
		public PaymentService(DataAccessFactory factory)
		{
			this.factory = factory;
		}

		public List<PaymentDTO> Get()
		{
			var data = factory.PaymentData().Get();// call Get() of DAL and get all the modeldata first 
			var mapper = MapperConfig.GetMapper();
			var datadto = mapper.Map<List<PaymentDTO>>(data); //Convert second

			return datadto;

		}

		public PaymentDTO Get(int id)
		{
			var data = factory.PaymentData().Get(id);
			return MapperConfig.GetMapper().Map<PaymentDTO>(data);
		}

		public bool Create(PaymentDTO p)
		{
			var modeldata = MapperConfig.GetMapper().Map<Payment>(p);
			return factory.PaymentData().Create(modeldata);

		}

		public bool Update(PaymentDTO data)
		{
			var modeldata = MapperConfig.GetMapper().Map<Payment>(data);
			return factory.PaymentData().Update(modeldata);
		}

		public bool Delete(int id)
		{
			return factory.PaymentData().Delete(id);
		}

		//Calling Feature method from DAL
		//Billing
		public bool GenerateBill(int oid)
		{
			//Calculate total amount for the order
			var orderitems = factory.OrderFeature().GetOrderItems(oid);
			decimal totalAmount = orderitems.Sum(oi => oi.Quantity * oi.UnitPrice);
			Console.WriteLine(totalAmount);

			//Current Payment Data
			var payment = factory.PaymentFeature().GetPaymentByOrderId(oid);

			if (payment == null)
			{
				//  Create a new payment
				payment = new Payment
				{
					OrderId = oid,
					Amount = totalAmount,
					Status = "Placed",
					PaymentDate = null,
					Method = "Cash On Delivery"
				};
				return factory.PaymentFeature().CreatePayment(payment);
			}
			else
			{
				// Update existing Payment
				payment.Amount = totalAmount;
				payment.Status = "Placed";
				payment.PaymentDate = null;
				payment.Method = "Cash On Delivery";
				return factory.PaymentFeature().UpdatePayment(payment);
			}
		}
	}
}

using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
	internal class PaymentRepo: IRepository<Payment>,IPaymentFeature
	{
		PMSContext db;
		public PaymentRepo(PMSContext db)
		{
			this.db = db;
		}
		//Basic CRUD Operations
		public bool Create(Payment obj)
		{
			var res = db.Payments.Add(obj);
			return db.SaveChanges() > 0;
		}

		public List<Payment> Get()
		{
			var data = db.Payments.ToList();
			return data;
		}

		public Payment Get(int id)
		{
			var data = db.Payments.Find(id);
			if (data == null)
			{
				throw new Exception("Payment not found");
			}
			return data;
		}

		public bool Update(Payment obj)
		{
			var ex = Get(obj.Id);
			if (ex == null)
				return false;
			db.Entry(ex).CurrentValues.SetValues(obj);
			return db.SaveChanges() > 0;
		}
		public bool Delete(int id)
		{
			var ex = db.Payments.Find(id);
			if (ex == null) return false;
			db.Payments.Remove(ex);
			return db.SaveChanges() > 0;
		}


		//Features
		//Getting the current Payment Details for an Order
		public Payment GetPaymentByOrderId(int oid)
		{
			var data= db.Payments.FirstOrDefault(p => p.OrderId == oid);
			if(data == null)
			{
				throw new Exception("Order with the id does not exists");
			}
			return data;
		}

		public bool UpdatePayment(Payment payment)
		{
			var ex= db.Payments.Find(payment.Id);
			if(ex==null) return  false;
			db.Entry(ex).CurrentValues.SetValues(payment);

			return db.SaveChanges() > 0;	
		}

		//Make a new Payment
	public bool CreatePayment(Payment payment)
{
    if (payment == null) return false;

    //FK safety check
    var orderExists = db.Orders.Any(o => o.Id == payment.OrderId);
    if (!orderExists)
    {
        throw new Exception($"OrderId {payment.OrderId} does not exist.");
    }

    db.Payments.Add(payment);
    return db.SaveChanges() > 0;
}

	}
}

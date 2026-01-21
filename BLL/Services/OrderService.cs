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
	public class OrderService 
	{
		DataAccessFactory factory;
		public OrderService(DataAccessFactory factory)
		{
			this.factory=factory;
		}

		public List<OrderDTO> Get()
		{
			var data = factory.OrderData().Get();
			var datadto= MapperConfig.GetMapper().Map<List<OrderDTO>>(data);
			return datadto;
		}

		public OrderDTO Get(int id)
		{
			var data = factory.OrderData().Get(id);
			var datadto= MapperConfig.GetMapper().Map<OrderDTO>(data);

			return datadto; 
		}
		public bool Create(OrderDTO c)
		{
			var mapper = MapperConfig.GetMapper();
			var data = mapper.Map<Order>(c); // Receive OrderDTO from Application Layer and converting to Order model for DAL to Insert in the table

			return factory.OrderData().Create(data);
		}

		public bool Update(OrderDTO c)
		{
			var data = MapperConfig.GetMapper().Map<Order>(c); // Receive OrderDTO from Application Layer and converting to Order model for DAL

			return factory.OrderData().Update(data);
		}

		public bool Delete(int id)
		{
			return factory.OrderData().Delete(id);
		}

		//Features...........

		public List<OrderProductDTO> GetProductsByOrderId(int oid)
		{
			var data= factory.OrderFeature().GetProductsByOrderId(oid);
			var mappeddata= MapperConfig.GetMapper().Map<List<OrderProductDTO>>(data);

			return mappeddata;
		}

	


	}
}

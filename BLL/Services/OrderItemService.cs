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
	public class OrderItemService
	{
		DataAccessFactory factory;
		public OrderItemService(DataAccessFactory factory)
		{
			this.factory = factory;
		}

		public List<OrderItemDTO> Get()
		{

			var data = factory.OrderItemData().Get();
			var count = data.Count;
		
			var mapper = MapperConfig.GetMapper();
			var datadto = mapper.Map<List<OrderItemDTO>>(data); //Converting List<Order> to List<OrderItemDTO> for the Presentation Layer

			return datadto;
		}

		//Get OrderItem by id for Presentation Layer
		public OrderItemDTO Get(int id)
		{
			var data = factory.OrderItemData().Get(id);
			var datadto = MapperConfig.GetMapper().Map<OrderItemDTO>(data); // Model to DTO conversion
																		   //return MapperConfig.GetMapper().Map<OrderItemDTO>(repo.Get(id));

			return datadto;
		}

		public bool Create(OrderItemDTO c)
		{
			var mapper = MapperConfig.GetMapper();
			var data = mapper.Map<OrderItem>(c); // Receive OrderItemDTO from Application Layer and converting to Order model for DAL to Insert in the table

			return factory.OrderItemData().Create(data);
		}

		public bool Update(OrderItemDTO c)
		{
			var mapper = MapperConfig.GetMapper();
			var data = mapper.Map<OrderItem>(c); // Receive OrderItemDTO from Application Layer and converting to Order model for DAL

			return factory.OrderItemData().Update(data);
		}

		public bool Delete(int id)
		{
			return factory.OrderItemData().Delete(id);
		}


	}
}

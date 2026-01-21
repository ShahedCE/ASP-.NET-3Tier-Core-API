using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		OrderService service;
		public OrderController(OrderService service)
		{
			this.service=service;
		}


		[HttpGet("all")]
		public IActionResult All()
		{
			var data = service.Get();
			return Ok(data);
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var data = service.Get(id);
			return Ok(data);
		}

		[HttpPost("create")]
		public IActionResult Create(OrderDTO c)
		{
			var res = service.Create(c);

			if (res == true)
			{
				return Ok(new { Msg = "Order Created"});
			}
			else
			{
				return BadRequest(new { Msg = "Order Creation Failed" });
			}
		}

		[HttpPost("update")]
		public IActionResult Update(OrderDTO c)
		{
			var res = service.Update(c);

			if (res == true)
			{
				return Ok(new { Msg = "Order Updated" });
			}
			else
			{
				return BadRequest(new { Msg = "Order Updation Failed" });
			}
		}

		[HttpDelete("delete/{id}")]
		public IActionResult Delete(int id)
		{
			var res = service.Delete(id);

			if (res == true)
			{
				return Ok(new { Msg = "Order Deleted" });
			}
			else
			{
				return BadRequest(new { Msg = "Order Deletion Failed" });
			}
		}


		//Feature: Get Products by Order ID
		[HttpGet("products/{oid}")]
		public IActionResult GetProductsByOrderId(int oid)
		{
			var data = service.GetProductsByOrderId(oid);
			return Ok(data);
		}

		
	}
}

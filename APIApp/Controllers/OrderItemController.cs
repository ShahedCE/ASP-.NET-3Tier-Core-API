using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderItemController : ControllerBase
	{
		OrderItemService service;
		public OrderItemController(OrderItemService service)
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
		public IActionResult Create(OrderItemDTO c)
		{
			var res = service.Create(c);

			if (res == true)
			{
				return Ok(new { Msg = "OrderItem Created" });
			}
			else
			{
				return BadRequest(new { Msg = "OrderItem Creation Failed" });
			}
		}

		[HttpPost("update")]
		public IActionResult Update(OrderItemDTO c)
		{
			var res = service.Update(c);

			if (res == true)
			{
				return Ok(new { Msg = "OrderItem Updated" });
			}
			else
			{
				return BadRequest(new { Msg = "OrderItem Updation Failed" });
			}
		}

		[HttpDelete("delete/{id}")]
		public IActionResult Delete(int id)
		{
			var res = service.Delete(id);

			if (res == true)
			{
				return Ok(new { Msg = "OrderItem Deleted" });
			}
			else
			{
				return BadRequest(new { Msg = "OrderItem Deletion Failed" });
			}
		}

	}
}

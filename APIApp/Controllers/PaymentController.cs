using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentController : ControllerBase
	{
		PaymentService service;
		public PaymentController(PaymentService service)
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
		public IActionResult Create(PaymentDTO c)
		{
			var res = service.Create(c);

			if (res == true)
			{
				return Ok(new { Msg = "Payment Created"});
			}
			else
			{
				return BadRequest(new { Msg = "Payment Creation Failed" });
			}
		}

		[HttpPost("update")]
		public IActionResult Update(PaymentDTO c)
		{
			var res = service.Update(c);

			if (res == true)
			{
				return Ok(new { Msg = "Payment Updated" });
			}
			else
			{
				return BadRequest(new { Msg = "Payment Updation Failed" });
			}
		}

		[HttpDelete("delete/{id}")]
		public IActionResult Delete(int id)
		{
			var res = service.Delete(id);

			if (res == true)
			{
				return Ok(new { Msg = "Payment Deleted", Success = res });
			}
			else
			{
				return BadRequest(new { Msg = "Payment Deletion Failed" });
			}
		}


		//Feature call
		[HttpPost("billing/{oid}")]
		public IActionResult Billig(int oid)
		{
			var res= service.GenerateBill(oid);
			if(res==true)
			{
				return Ok(new { Msg = "Billing Successful" });
			}
			else
			{
				return BadRequest(new { Msg = "Billing Failed" });
			}
		}


	}
}

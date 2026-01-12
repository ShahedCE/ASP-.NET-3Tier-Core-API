using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		ProductService service;

		public ProductController(ProductService service)
		{
			this.service = service;
		}

		[HttpGet("all")]
		public IActionResult Get()
		{
			var res=service.Get();
			return Ok(res);	
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var res=service.Get(id);
			return Ok(res);
		}

		[HttpPost("create")]
		public IActionResult Create(ProductDTO p)
		{
			var res= service.Create(p);
			return Ok(res);
		}
	}
}

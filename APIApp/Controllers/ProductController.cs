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
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var res= service.Create(p);
			return Ok(res);
		}
		[HttpPost("update")]
		public IActionResult Update(ProductDTO p)
		{
			var res = service.Update(p);
			return Ok(res);
		}

		[HttpDelete("delete/{id}")]
		public IActionResult Delete(int id)
		{
			var res= service.Delete(id);
			return Ok(res);
		}

		//Calling Feature methods

		[HttpGet("categorybyid/{id}")]
		public IActionResult GetCategory(int id)
		{
			var data = service.GetCategoryByProductId(id);
			return Ok(data);
		}

		[HttpGet("categorybyname/{name}")]
		public IActionResult GetCategory(string name)
		{
			var data = service.GetCategoryByProductName(name);
			return Ok(data);
		}
	}
}

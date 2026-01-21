using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		   CategoryService service;  //putting instance of CategoryService to use its methods

		public CategoryController(CategoryService service) //Receiving CategoryService instance from DI container
		{
						this.service = service;
		}

		[HttpGet("all")]
		public IActionResult All()
		{
			var data= service.Get();
			return Ok(data);
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var data= service.Get(id);
			return Ok(data);
		}

		[HttpPost("create")]
		public IActionResult Create(CategoryDTO c)
		{
			var res = service.Create(c);

			if (res == true)
			{
				return Ok(new { Msg = "Category Created" });
			}
			else
			{
				return BadRequest(new { Msg = "Category Creation Failed" });
			}
		}

		[HttpPost("update")]
		public IActionResult Update(CategoryDTO c)
		{
			var res = service.Update(c);

			if (res == true)
			{
				return Ok(new { Msg = "Category Updated"});
			}
			else
			{
				return BadRequest(new { Msg = "Category Updation Failed" });
			}
		}

		[HttpDelete("delete/{id}")]
		public IActionResult Delete(int id)
		{
			var res = service.Delete(id);

			if (res == true)
			{
				return Ok(new { Msg = "Category Deleted"});
			}
			else
			{
				return BadRequest(new { Msg = "Category Deletion Failed" });
			}
		}

		//Features...........
		[HttpGet("find/{name}")]
		public IActionResult FindCatByName(string name)
		{
			 var data= service.FindCategoryByName(name);	
			return Ok(data);
		}

		[HttpGet("all/withproducts")]
		public IActionResult GetCategoriesWithProducts()
		{
			var data = service.GetWithProducts();
			return Ok(data);
		}
		[HttpGet("all/withproducts/{id}")]
		public IActionResult GetCategoryWithProducts(int id)
		{
			var data = service.GetWithProducts(id);
			return Ok(data);
		}

		[HttpGet("findbyname/{name}")]
		public IActionResult FindProductsByCategoryName(string name)
		{
			var data = service.FindByNameWithProducts(name);
			return Ok(data);
		}

		[HttpGet("highest/products")]
		public IActionResult CategoryWithHighestProducts()
		{
			var data = service.HighestProducts();
			return Ok(data);
		}


		}
}

using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class CategoryService
	{
		DataAccessFactory factory;  //Dependency Inversion 
		public CategoryService(DataAccessFactory factory) // Receiving the Repon instance from DI container
		{
			this.factory = factory;  
		}
		//repo holding the CtegoryRepo datasource methods


		//Get all categories for Presentation Layer
		public List <CategoryDTO> Get()
		{
			
			var data = factory.CategoryData().Get();
			var count = data.Count;
			Console.WriteLine("Total Category: "+count);
			var mapper = MapperConfig.GetMapper();
			var datadto = mapper.Map<List<CategoryDTO>>(data); //Converting List<Category> to List<CategoryDTO> for the Presentation Layer

			return datadto;
		}
	
		//Get category by id for Presentation Layer
		public CategoryDTO Get (int id)
		{
			var data = factory.CategoryData().Get(id);
			var datadto = MapperConfig.GetMapper().Map<CategoryDTO>(data); // Model to DTO conversion
			//return MapperConfig.GetMapper().Map<CategoryDTO>(repo.Get(id));

			return datadto;
		}

		public bool Create(CategoryDTO c)
		{
			var mapper = MapperConfig.GetMapper();
			var data = mapper.Map<Category>(c); // Receive CategoryDTO from Application Layer and converting to Category model for DAL to Insert in the table

			return factory.CategoryData().Create(data);
		}

		public bool Update(CategoryDTO c)
		{
			var mapper = MapperConfig.GetMapper();
			var data = mapper.Map<Category>(c); // Receive CategoryDTO from Application Layer and converting to Category model for DAL

			return factory.CategoryData().Update(data);
		}

		public bool Delete(int id)
		{
			return factory.CategoryData().Delete(id);
		}

		//Features...........
		public List<CategoryProductDTO> GetWithProducts()
		{
			var data = factory.CategoryFeature().GetWithProducts();
			var mapper = MapperConfig.GetMapper();
			var datadto = mapper.Map<List<CategoryProductDTO>>(data); //Converting List<Category> to List<CategoryDTO> for the Presentation Layer
			return datadto;
		}

		public CategoryProductDTO GetWithProducts(int id)
		{
			var data= factory.CategoryFeature().GetWithProducts(id);
			var datadto = MapperConfig.GetMapper().Map<CategoryProductDTO>(data);
			return datadto;

		}

		public CategoryProductDTO FindByNameWithProducts(string name)
		{
			var data = factory.CategoryFeature().FindByNameWitProducts(name);
			var mapper = MapperConfig.GetMapper();
			var datadto = mapper.Map<CategoryProductDTO>(data); //Converting List<Category> to List<CategoryDTO> for the Presentation Layer
			return datadto;
		}

		public CategoryDTO FindCategoryByName(string name)
		{
			var data= factory.CategoryFeature().FindByName(name);
			var datadto = MapperConfig.GetMapper().Map<CategoryDTO>(data);
			return datadto;
		}

		public CategoryProductDTO HighestProducts()
		{
			var data = factory.CategoryFeature().HighestProducts();
			var mapper = MapperConfig.GetMapper();
			var datadto = mapper.Map<CategoryProductDTO>(data); //Converting List<Category> to List<CategoryDTO> for the Presentation Layer
			return datadto;
		}
	}
}

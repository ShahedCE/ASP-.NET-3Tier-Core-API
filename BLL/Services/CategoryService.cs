using BLL.DTOs;
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
		CategoryRepo repo;
		public CategoryService(CategoryRepo repo) // Receiving the CategoryRepo instance from DI container
		{
			this.repo = repo;  
		}
		//repo holding the CtegoryRepo datasource methods


		//Get all categories for Presentation Layer
		public List <CategoryDTO> Get()
		{
			var data = repo.Get();
			var mapper = MapperConfig.GetMapper();
			var datadto = mapper.Map<List<CategoryDTO>>(data); //Converting List<Category> to List<CategoryDTO> for the Presentation Layer

			return datadto;
		}

		//Get category by id for Presentation Layer
		public CategoryDTO Get (int id)
		{
			var data = repo.Get(id);
			var datadto = MapperConfig.GetMapper().Map<CategoryDTO>(data); // Model to DTO conversion
			//return MapperConfig.GetMapper().Map<CategoryDTO>(repo.Get(id));

			return datadto;
		}

		public bool Create(CategoryDTO c)
		{
			var mapper = MapperConfig.GetMapper();
			var data = mapper.Map<Category>(c); // Receive CategoryDTO from Application Layer and converting to Category model for DAL to Insert in the table

			return repo.Create(data);
		}

		public bool Update(CategoryDTO c)
		{
			var mapper = MapperConfig.GetMapper();
			var data = mapper.Map<Category>(c); // Receive CategoryDTO from Application Layer and converting to Category model for DAL

			return repo.Update(data);
		}

		public bool Delete(int id)
		{
			return repo.Delete(id);
		}

	}
}

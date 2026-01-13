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
	public class ProductService
	{
		//ProductRepo repo;
		Repository<Product> repo; //Using Generic Repository

		public ProductService(Repository<Product> repo)
		{
			this.repo = repo;
		}

		public List<ProductDTO> Get()
		{
			var data = repo.Get();// call Get() of DAL and get all the modeldata first 
			var mapper= MapperConfig.GetMapper(); 
			var datadto= mapper.Map<List<ProductDTO>>(data); //Convert second

			return datadto;

		}

		public ProductDTO Get(int id)
		{
			var data = repo.Get(id);
			return MapperConfig.GetMapper().Map<ProductDTO>(data);
		}

		public bool Create(ProductDTO p)
		{
			var modeldata = MapperConfig.GetMapper().Map<Product>(p);
			return repo.Create(modeldata); 
			
		}

		public bool Update(ProductDTO data)
		{
			var modeldata = MapperConfig.GetMapper().Map<Product>(data);
			return repo.Update(modeldata);
		}

		public bool Detele(int id)
		{
			return repo.Delete(id);
		}
		
	}
}

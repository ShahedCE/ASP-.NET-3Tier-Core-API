using BLL.DTOs;
using DAL;
using DAL.EF.Models;

namespace BLL.Services
{
	public class ProductService
	{
		DataAccessFactory factory;
	//	Repository<Product> factory.ProductData(); //Using Generic repository

		public ProductService(DataAccessFactory factory)
		{
			this.factory = factory;
		}

		public List<ProductDTO> Get()
		{
			var data = factory.ProductData().Get();// call Get() of DAL and get all the modeldata first 
			var mapper= MapperConfig.GetMapper(); 
			var datadto= mapper.Map<List<ProductDTO>>(data); //Convert second

			return datadto;

		}

		public ProductDTO Get(int id)
		{
			var data = factory.ProductData().Get(id);
			return MapperConfig.GetMapper().Map<ProductDTO>(data);
		}

		public bool Create(ProductDTO p)
		{
			var modeldata = MapperConfig.GetMapper().Map<Product>(p);
			return factory.ProductData().Create(modeldata); 
			
		}

		public bool Update(ProductDTO data)
		{
			var modeldata = MapperConfig.GetMapper().Map<Product>(data);
			return factory.ProductData().Update(modeldata);
		}

		public bool Detele(int id)
		{
			return factory.ProductData().Delete(id);
		}
		
	}
}

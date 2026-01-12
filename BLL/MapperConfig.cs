using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;

namespace BLL
{
	public class MapperConfig
	{
		static MapperConfiguration cfg = new MapperConfiguration(cfg =>
		{
			cfg.CreateMap<Category, CategoryDTO>().ReverseMap(); //<Source, Destination>
			cfg.CreateMap<Product,ProductDTO>().ReverseMap();
		});

		public static Mapper GetMapper()
		{
			return new Mapper(cfg);
		}
	}
}

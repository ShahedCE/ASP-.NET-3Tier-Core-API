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
			cfg.CreateMap<Category, CategoryProductDTO>().ReverseMap();
			cfg.CreateMap<Product,ProductCategoryDTO>().ReverseMap();
			cfg.CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
			cfg.CreateMap<Order, OrderDTO>().ReverseMap();	
			cfg.CreateMap<Payment, PaymentDTO>().ReverseMap();

			cfg.CreateMap<Order, OrderProductDTO>() //Mapping OrderItem to OrderItemProductDTO
			.ForMember(dest=> dest.Products,
			opt=> opt.MapFrom(src=>src.OrderItems));
			
			cfg.CreateMap<OrderItem, OrderItemProductDTO>()
			   .ForMember(dest => dest.ProductId, //Destinaion Property which is to be mapped in OrderItemProductDTO
						  opt => opt.MapFrom(src => src.Product.Id)) 
			   .ForMember(dest => dest.ProductName,
						  opt => opt.MapFrom(src => src.Product.Name));


		});

		public static Mapper GetMapper()
		{
			return new Mapper(cfg);
		}
	}
}

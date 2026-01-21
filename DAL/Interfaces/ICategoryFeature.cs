using DAL.EF.Models;

namespace DAL.Interfaces
{
	public interface ICategoryFeature
	{
		List<Category> GetWithProducts();
		Category GetWithProducts(int id);
		Category FindByName(string name);
		Category FindByNameWitProducts(string name);
		Category HighestProducts();

	}
}

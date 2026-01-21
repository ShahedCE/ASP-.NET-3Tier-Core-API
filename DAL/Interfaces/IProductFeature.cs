using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
	public interface IProductFeature
	{
	    Product GetCategoryByProductId(int id);
		List <Product> GetCategoryByProductName(string name);


	}
}

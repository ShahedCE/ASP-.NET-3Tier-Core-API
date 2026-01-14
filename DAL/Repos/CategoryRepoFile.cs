using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
	public class CategoryRepoFile 
	{

		/*Should have an interface for guidelines that all repos should follow and 
		 * could not implement own functions like public bool CreateCategory(Category obj) */
		public bool CreateCategory(Category obj)
		{
			return true;
		}

		public void GetCategoryById()
		{

		}
	}
}

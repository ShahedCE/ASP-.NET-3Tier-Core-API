using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
	//This is an interface
	public interface IRepository<T> where T : class
	{
		//Declaring the signaatures of the methods for all repositories but without implementation
		public List<T> Get();
		public T Get(int id);
		public bool Create(T obj);
		public bool Update(T obj);
		public bool Delete(int id);

	}
}

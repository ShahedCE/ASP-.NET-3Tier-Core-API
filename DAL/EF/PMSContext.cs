using DAL.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
	public class PMSContext : DbContext
	{
		public PMSContext(DbContextOptions<PMSContext> opt): base(opt) { } //constructor to  receive all the database configuration from DI(provider, connection string, options)


		//Mapping all the tables
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<Payment> Payments { get; set; }



	}
}

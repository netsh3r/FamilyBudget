using FamiliBudget.Serv.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiliBudget.Serv.Context
{
	internal class FBContext : DbContext
	{
		//static FBContext()
		//{
		//	Database.SetInitializer<FBContext>(new FBContextInitializer());
		//}
		public FBContext() : base("DBConnection") 
		{
			this.Configuration.LazyLoadingEnabled = false;
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Budget> Budgets { get; set; }
		public DbSet<Role> Roles { get; set; }

	}
}

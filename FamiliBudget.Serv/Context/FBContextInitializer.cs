using FamiliBudget.Serv.Entity;
using System.Collections.Generic;
using System.Data.Entity;

namespace FamiliBudget.Serv.Context
{
	internal class FBContextInitializer : IDatabaseInitializer<FBContext>
	{
		public void InitializeDatabase(FBContext context)
		{
			List<User> users = new List<User>()
			{
				new User(){ ID = 1, Login = "Admin", Password="shiFdsaq1"}
			};
			context.Users.AddRange(users);
			context.SaveChanges();
		}
	}
}
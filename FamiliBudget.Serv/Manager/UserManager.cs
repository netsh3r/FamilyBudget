using FamiliBudget.Serv.Context;
using FamiliBudget.Serv.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FamiliBudget.Serv.Manager
{
	public class UserManager : EntityManager<User, int>
	{
		internal User Login(string userName, string password)
		{
			using(var db = new FBContext())
			{
				return db.Users.FirstOrDefault(t => t.Login == userName && t.Password == password);
			}
		}
		internal User Find(Expression<Func<User, bool>> expression)
		{
			using (var db = new FBContext())
			{
				return db.Users.FirstOrDefault(expression);
			}
		}
		internal User Login(Expression<Func<User,bool>> expression)
		{
			using (var db = new FBContext())
			{
				return db.Users.FirstOrDefault(expression);
			}
		}

		internal User FindByEmail(string email)
		{
			using (var db = new FBContext())
			{
				return db.Users.FirstOrDefault(t => t.Email == email);
			}
		}
	}
}

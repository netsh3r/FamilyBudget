using FamiliBudget.Serv.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FamiliBudget.Serv
{
	public interface IDBService
	{
		void SaveUser(User user);
		void SaveBudget(Budget budget);
		Budget CreateBudget(Budget budget);
		User CreateUser(User user);
		List<Budget> GetBudgetsByUserId(long userId);
		List<Budget> GetBudgets();
		List<User> GetAllUser();
		User Login(string userName, string Password);
		User GetUser(string email);
		User FindUserById(int id);
		Budget FindBudgetByID(int id);
		User Login(Expression<Func<User, bool>> expression);
		User FindUser(Expression<Func<User, bool>> expression);
	}
}
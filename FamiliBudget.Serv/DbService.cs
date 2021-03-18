using FamiliBudget.Serv.Entity;
using FamiliBudget.Serv.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FamiliBudget.Serv
{
    
    public class DbService : IDBService
    {
        public UserManager UserManager { get; set; }
        public BudgetManager BudgetManager { get; set; }
        
        public List<User> GetAllUser()
		{
            return UserManager.FindAll();
		}
        public List<Budget> GetBudgets()
		{
            return BudgetManager.FindAll();
        }
        public List<Budget> GetBudgetsByUserId(long userId)
        {
            return BudgetManager.FindAllByUserId(userId);
        }
        public Budget FindBudgetByID(int id)
		{
            return BudgetManager.FindById(id);
		}
        public User CreateUser(User user)
        {
            return UserManager.Add(user);
        }

        public void SaveBudget(Budget budget)
		{
            BudgetManager.Edit(budget);
		}
        public void SaveUser(User user)
        {
            UserManager.Edit(user);
        }

        public Budget CreateBudget(Budget budget)
		{
            return BudgetManager.Add(budget);
		}
        public User FindUserById(int id)
        {
            return UserManager.FindById(id);
        }
        public User Login(string userName, string Password)
		{
            return UserManager.Login(userName, Password);
		}
        public User Login(Expression<Func<User,bool>> expression)
		{
            return UserManager.Login(expression);
		}
        public User FindUser(Expression<Func<User, bool>> expression)
		{
            return UserManager.Find(expression);
		}

        public User GetUser(string email)
		{
            return UserManager.FindByEmail(email);
		}
	}
}

using FamiliBudget.Serv.Context;
using FamiliBudget.Serv.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiliBudget.Serv.Manager
{
	public class BudgetManager: EntityManager<Budget,int>
	{
		public List<Budget> FindAllByUserId(long id)
		{
			List<Budget> budgets = null;
			using (var db = new FBContext())
			{
				budgets= db.Budgets.Where(t=> t.UserID==id).ToList();
			}

			return budgets;
		}
	}
}

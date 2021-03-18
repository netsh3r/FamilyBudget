using FamiliBudget.Serv;
using FamiliBudget.Serv.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FamilyBudget.Controllers
{
    public class BudgetApiController : ApiController
    {
		private IDBService DBService;
		public BudgetApiController(IDBService DBService)
		{
			this.DBService = DBService;

		}
		public List<Budget> Get(int tokenId)
		{
			var user = DBService.FindUser(t => t.TokenId == tokenId);
			return DBService.GetBudgetsByUserId(user.ID);
		}
	}
}
using FamiliBudget.Serv;
using FamiliBudget.Serv.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FamilyBudget.Controllers
{
    public class PositionApiController : ApiController
    {
		private IDBService DBService;
		public PositionApiController(IDBService DBService)
		{
			this.DBService = DBService;

		}
		public List<Position> Get(int budgetId)
		{
			return DBService.FindBudgetByID(budgetId).Positions;
		}
	}
}
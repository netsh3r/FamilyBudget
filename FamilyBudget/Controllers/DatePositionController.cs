using FamiliBudget.Serv;
using FamiliBudget.Serv.Entity;
using FamiliBudget.Serv.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FamilyBudget.Controllers
{
    public class DatePositionController : ApiController
    {
		private IDBService DBService;
		public DatePositionController(IDBService DBService)
		{
			this.DBService = DBService;

		}
		public List<Position> Get(int budgetId)
		{
			List<Position> positions = new List<Position>();
			foreach(var position in DBService.FindBudgetByID(budgetId).Positions)
			{
				if(position.DayInWeeks != null && position.WeekInMonths != null)
				{
					var days = JsonConvert.DeserializeObject<List<int>>(position.DayInWeeks);
					var weeks = JsonConvert.DeserializeObject<List<int>>(position.WeekInMonths);
					var numberDayOfWeek = Convert.ToInt16(DateTime.Now.DayOfWeek.ToString("D").Replace('0', '7'));
					var numberWeekOfTheMonth = (DateTime.Now.Day + numberDayOfWeek - 2) / 7 + 1;
					if(weeks.Contains(numberWeekOfTheMonth) && days.Contains(numberDayOfWeek==0?6: numberDayOfWeek-1))
					{
						positions.Add(position);
					}
				}
			}
			return positions;
		}
	}
}
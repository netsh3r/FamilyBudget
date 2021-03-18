using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiliBudget.Serv.Entity
{
	public class Position: Entity<long>
	{
		public int MonthAmount { get; set; }
		public int Amount { get; set; }
		public int CountInDat { get; set; }
		public string DayInWeeks { get; set; }
		public int DayInWeek { get; set; }
		public int WeekInMonth { get; set; }
		public string WeekInMonths { get; set; }
		public string Name { get; set; }
	}
}

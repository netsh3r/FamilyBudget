using FamiliBudget.Serv.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiliBudget.Serv.Enums
{
	public enum DateEnum:int
	{
		[StringValue("Пн")]
		Monday = 0,
		[StringValue("Вт")]
		Tuesday = 1,
		[StringValue("Ср")]
		Wednesday = 2,
		[StringValue("Чт")]
		Thursday = 3,
		[StringValue("Пт")]
		Friday = 4,
		[StringValue("Сб")]
		Saturday = 5,
		[StringValue("Вс")]
		Sunday = 6
	}
}

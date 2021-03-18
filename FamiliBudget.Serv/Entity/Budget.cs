using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FamiliBudget.Serv.Entity
{
	public class Budget :Entity<int>
	{
		public string Name { get; set; }
		public int Amount { get; set; }
		public string JsonPositions { get; set; }
		public int? UserID { get; set; }
		public virtual User User { get; set; }
		[NotMapped]
		public List<Position> Positions
		{
			get
			{
				if(!string.IsNullOrEmpty(JsonPositions))
				{
					return JsonConvert.DeserializeObject<List<Position>>(JsonPositions);
				}
				return new List<Position>();
			}
			set
			{
				JsonPositions = JsonConvert.SerializeObject(value);
			}
		} 
	}
}

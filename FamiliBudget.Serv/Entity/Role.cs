using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiliBudget.Serv.Entity
{
	[Table("Role")]
	public class Role:Entity<int>
	{
		public string Name { get; set; }
		public ICollection<User> User { get; set; } = new List<User>();
	}
}

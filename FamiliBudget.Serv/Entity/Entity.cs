using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamiliBudget.Serv.Entity
{
	public class Entity<IdT>
	{
		//[Key]
		public IdT ID { get; set; }
	}
}

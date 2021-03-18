using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiliBudget.Serv.Attributes
{
	public class StringValueAttribute:Attribute
	{
		public string Name { get; set; }
		public StringValueAttribute(string name)
		{
			this.Name = name;
		}
	}
}

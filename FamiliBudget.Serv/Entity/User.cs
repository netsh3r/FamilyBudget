using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiliBudget.Serv.Entity
{
	[Table("User")]
	public class User : Entity<int>
	{
		public User()
		{
			Budgets = new List<Budget>();
		}
		[DisplayName("Токен подключения к тг боту")]
		public int TokenId { get; set; }
		[Required]
		[DisplayName("Логин")]
		public string Login { get; set; }
		[Required]
		[DisplayName("Пароль")]
		public string Password { get; set; }
		public int? RoleID { get; set; }
		public virtual Role Role { get; set; }
		public virtual List<Budget> Budgets { get; set; } 
		//[Required]
		[DisplayName("Email")]
		[DataType(DataType.EmailAddress, ErrorMessage ="E-mail not valid")]
		public string Email { get; set; }

		public bool InRoles(string roles)
		{
			if (string.IsNullOrWhiteSpace(roles))
			{
				return false;
			}

			var rolesArray = roles.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
			//foreach (var role in rolesArray)
			//{
			//	var hasRole = UserRoles.Any(p => string.Compare(p.Role.Code, role, true) == 0);
			//	if (hasRole)
			//	{
			//		return true;
			//	}
			//}
			return false;
		}
	}
}

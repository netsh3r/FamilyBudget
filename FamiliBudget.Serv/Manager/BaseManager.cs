using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiliBudget.Serv.Manager
{
	public abstract class BaseManager<T,IdT>
	{
		//</inheritdoc>
		public abstract void Delete(IdT id);
		//</inheritdoc>
		public abstract T FindById(IdT id);
		//</inheritdoc>
		public abstract void Edit(T entityModel);
		//</inheritdoc>
		public abstract List<T> FindAll();
		//</inheritdoc>
		public abstract T Add(T model);
		//</inheritdoc>
		public abstract void Delete(T model);
	}
}

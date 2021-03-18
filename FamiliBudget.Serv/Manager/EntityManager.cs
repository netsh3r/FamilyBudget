using FamiliBudget.Serv.Context;
using FamiliBudget.Serv.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiliBudget.Serv.Manager
{
	public class EntityManager<T, IdT> : BaseManager<T, IdT> where T : Entity<IdT>
	{
		private static EntityManager<T, IdT> _instance;
		public static EntityManager<T, IdT> Instance
		{
			get
			{
				return _instance ?? (_instance = new EntityManager<T, IdT>());
			}
		}
		//</inheritdoc>
		public override void Delete(IdT id)
		{
			try
			{
				var model = FindById(id);
				using (var context = new FBContext())
				{
					var _dbset = context.Set<T>();
					_dbset.Remove(model);
					context.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
		//</inheritdoc>
		public override void Delete(T model)
		{
			try
			{
				using (var context = new FBContext())
				{
					var _dbset = context.Set<T>();
					_dbset.Attach(model);
					context.Entry(model).State = EntityState.Deleted;
					context.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
		//</inheritdoc>
		public override T FindById(IdT id)
		{
			try
			{
				T entityModel = null;
				using(var context = new FBContext())
				{
					var _dbset = context.Set<T>();
					entityModel= _dbset.Find(id);
				}
				return entityModel;


			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return null;
			}
		}
		//</inheritdoc>
		public override void Edit(T entityModel)
		{
			try
			{
				using (var context = new FBContext())
				{
					context.Entry(entityModel).State = EntityState.Modified;
					context.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}

		}
		//</inheritdoc>
		public override List<T> FindAll()
		{
			List<T> list = new List<T>();
			try
			{
				using (var context = new FBContext())
				{
					var _dbset = context.Set<T>();
					list = _dbset.ToList();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}

			return list;
		}
		//</inheritdoc>
		public override T Add(T model)
		{
			try
			{
				using (var context = new FBContext())
				{
					var _dbset = context.Set<T>();
					_dbset.AddRange(new List<T>() { model });
					context.SaveChanges();
					return model;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return null;
			}
		}
	}
}

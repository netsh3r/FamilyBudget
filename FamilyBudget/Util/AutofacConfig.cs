using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using FamiliBudget.Serv;
using FamiliBudget.Serv.Manager;
using FamilyBudget.Global.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FamilyBudget.Util
{
	public class AutofacConfig
	{
		public static void ConfigureContainer()
		{
			var builder = new ContainerBuilder();
			var config = GlobalConfiguration.Configuration;
			// регистрируем контроллер в текущей сборке
			builder.RegisterControllers(typeof(WebApiApplication).Assembly);
			builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);
			builder.RegisterWebApiFilterProvider(config);
			builder.RegisterWebApiModelBinderProvider();
			// регистрируем споставление типов
			builder.RegisterType<DbService>().As<IDBService>()
				.WithProperty("UserManager",new UserManager())
				.WithProperty("BudgetManager",new BudgetManager());

			builder.RegisterType<CustomAuthentication>().As<IAuthentication>();
			// создаем новый контейнер с теми зависимостями, которые определены выше
			var container = builder.Build();
			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
			// установка сопоставителя зависимостей
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}
using FamiliBudget.Serv;
using FamiliBudget.Serv.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace FamilyBudget.Global.Auth
{
	public class CustomAuthentication : IAuthentication
	{
		private const string cookieName = "__AUTH_COOKIE";
		private IDBService dBService;
		public CustomAuthentication(IDBService dBService)
		{
			this.dBService = dBService;
		}
		public HttpContext HttpContext { get; set; }
		private IPrincipal _currentUser;
		public IPrincipal CurrentUser
		{
			get
			{
				if (_currentUser == null)
				{
					try
					{
						HttpCookie authCookie = HttpContext.Request.Cookies.Get(cookieName);
						if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
						{
							var ticket = FormsAuthentication.Decrypt(authCookie.Value);
							_currentUser = new UserProvider(ticket.Name, dBService);
						}
						else
						{
							_currentUser = new UserProvider(null, null);
						}
					}
					catch (Exception ex)
					{
						_currentUser = new UserProvider(null, null);
					}
				}
				return _currentUser;
			}
		}

		public User Login(string userName, string Password, bool isPersistent)
		{
			User retUser = dBService.Login(userName, Password);
			if (retUser != null)
			{
				CreateCookie(userName, isPersistent);
			}
			return retUser;
		}

		private void CreateCookie(string userName, bool isPersistent = false)
		{
			var ticket = new FormsAuthenticationTicket(
				  1,
				  userName,
				  DateTime.Now,
				  DateTime.Now.Add(FormsAuthentication.Timeout),
				  isPersistent,
				  string.Empty,
				  FormsAuthentication.FormsCookiePath);

			// Encrypt the ticket.
			var encTicket = FormsAuthentication.Encrypt(ticket);

			// Create the cookie.
			var AuthCookie = new HttpCookie(cookieName)
			{
				Value = encTicket,
				Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
			};
			HttpContext.Response.Cookies.Set(AuthCookie);
		}
		public void LogOut()
		{
			var httpCookie = HttpContext.Response.Cookies[cookieName];
			if (httpCookie != null)
			{
				httpCookie.Value = string.Empty;
			}
		}

		public User Login(string login)
		{
			throw new NotImplementedException();
		}
	}
}
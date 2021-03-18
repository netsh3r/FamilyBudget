using FamiliBudget.Serv;
using FamiliBudget.Serv.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FamilyBudget.Controllers
{
    public class UserApiController : ApiController
    {
        private IDBService DBService;
        public UserApiController(IDBService DBService)
		{
            this.DBService = DBService;

        }
        // GET api/values
        public IEnumerable<int> Get()
        {
            var users = DBService.GetAllUser();
            return users.Select(t => t.TokenId).ToList();
		}

        // GET api/values/5
        public object Get(int id)
        {
            var user = DBService.FindUser(t=> t.TokenId == id);
            return user;
        }

        // POST api/values
        public void Post(string value)
        {
			var user = JsonConvert.DeserializeObject<User>(value);
            var thisUser = DBService.FindUser(t => t.TokenId == user.TokenId);

            if (thisUser == null)
			{
				DBService.CreateUser(user);
			}
		}

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
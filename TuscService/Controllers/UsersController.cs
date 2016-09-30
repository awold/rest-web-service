using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

using TuscData;

namespace TuscService.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("users")]
        public IEnumerable<User> Get()
        {
            return DataManager.GetUsers();
        }

        [HttpPost]
        [Route("users")]
        public int? Post(User user)
        {
            return DataManager.CreateUser(user);
        }

        [HttpGet]
        [Route("users/{id}")]
        public User Get(int id)
        {
            return DataManager.GetUsers().FirstOrDefault(u => u.Id == id);
        }

        [HttpGet]
        [Route("users")]
        public IEnumerable<User> Get(String sortBalance)
        {
            IEnumerable<User> users = DataManager.GetUsers();

            return "ASC".Equals(sortBalance) ? users.OrderBy(u => u.Balance) : users.OrderByDescending(u => u.Balance);
        }

        [HttpPut]
        [Route("users/{id}")]
        public void Put(int id, [FromBody]User user)
        {
            user.Id = id;

            DataManager.UpdateUser(user);
        }

        [HttpDelete]
        [Route("users/{id}")]
        public void Delete(int id)
        {
            DataManager.DeleteUser(id);
        }
    }
}
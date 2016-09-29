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

        [HttpGet]
        [Route("users/{id}")]
        public User Get(int id)
        {
            return DataManager.GetUsers().Where(p => p.Id == id).FirstOrDefault();
        }

        [HttpPost]
        [Route("users")]
        public int? Post([FromBody]User user)
        {
            return DataManager.CreateUser(user);
        }

        [HttpPut]
        [Route("users/{id}")]
        public void Put( int id, [FromBody]User user)
        {
            DataManager.UpdateUser(user);
        }

        [HttpDelete]
        [Route("users/{id}")]
        public void Delete(int id)
        {
            DataManager.DeleteUser(id);
        }

        [HttpGet]
        [Route("users")]
        public IEnumerable<User> GetUsersSortedByBalance(string sortBalance)
        {
            if (sortBalance.Trim() == "ASC")
            {
                return DataManager.GetUsers().OrderBy(u => u.Balance);
            }
            else 
            {
                return DataManager.GetUsers().OrderByDescending(u => u.Balance);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using TuscData;

namespace TuscService.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/users
        [HttpGet]
        [Route("users")]
        public IEnumerable<User> Get()
        {
            return DataManager.GetUsers();
        }

        // GET api/products/5
        [HttpGet]
        [Route("users/{id}")]
        public User Get(int id)
        {
            return DataManager.GetUsers().FirstOrDefault(p => p.Id == id);
        }

        // GET api/users?sortBalance={ASC|DESC}
        [HttpGet]
        [Route("users")]
        public IEnumerable<User> GetSortedUsers(string sortBalance)
        {
            if (sortBalance.Equals("ASC"))
            {
                return DataManager.GetUsers().OrderBy(p => p.Balance);
            }
            else
            {
                return DataManager.GetUsers().OrderByDescending(p => p.Balance);
            }
        }

        // POST api/users
        [HttpPost]
        [Route("users")]
        public int? Post([FromBody]User user)
        {
            return DataManager.CreateUser(user);
        }

        // PUT api/users/5
        [HttpPut]
        [Route("users/{id}")]
        public void Put(int id, [FromBody]User user)
        {
            user.Id = id;

            DataManager.UpdateUser(user);
        }

        // DELETE api/users/5
        [HttpDelete]
        [Route("users/{id}")]
        public void Delete(int id)
        {
            DataManager.DeleteUser(id);
        }
    }
}
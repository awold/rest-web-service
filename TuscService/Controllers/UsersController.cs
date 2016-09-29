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
        // Get Users
        [HttpGet]
        [Route("users")]
        public IEnumerable<User> Get()
        {
            return DataManager.GetUsers();
        }

        // Get a specific user
        [HttpGet]
        [Route("users/{id}")]
        public User Get(int id)
        {
            return DataManager.GetUsers().Where(u => u.Id == id).FirstOrDefault();
        }

        // Post a user
        [HttpPost]
        [Route("users")]
        public int? Post([FromBody]User user)
        {
            return DataManager.CreateUser(user);
        }

        // Update a user (all but the ID property)
        [HttpPut]
        [Route("users/{id}")]
        public void Put(int id, User user)
        {
            user.Id = id;
            DataManager.UpdateUser(user);
        }

        //Delete a user
        [HttpDelete]
        [Route("users/{id}")]
        public void Delete(int id)
        {
            DataManager.DeleteUser(id);
        }

        // GET api/users?sortBalance={ASC|DESC}
        [HttpGet]
        [Route("users")]
        public IEnumerable<User> GetUsersSortedByBalance(string sortBalance)
        {
            if (sortBalance.ToLower().Equals("asc"))
                return DataManager.GetUsers().OrderBy(u => u.Balance);
            else
                return DataManager.GetUsers().OrderByDescending(u => u.Balance);
        }
    }
}

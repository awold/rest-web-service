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

        // GET api/users?sortBalance={ASC|DESC}
        [HttpGet]
        [Route("users")]
        public IEnumerable<User> Get(string sortBalance)
        {
            IEnumerable<User> users;

            if (sortBalance.Equals("ASC"))
                users = DataManager.GetUsers().OrderBy(u => u.Balance);
            else if (sortBalance.Equals("DESC"))
                users = DataManager.GetUsers().OrderByDescending(u => u.Balance);
            else
                users = null;

            return users;
        }

        // GET api/users/{id}
        [HttpGet]
        [Route("users/{id}")]
        public User Get(int id)
        {
            return DataManager.GetUsers().Where(u => u.Id == id).FirstOrDefault();
        }

        // POST api/users
        [HttpPost]
        [Route("users")]
        public int? Post([FromBody]User user)
        {
            return DataManager.CreateUser(user);
        }

        // PUT api/users/{id}
        [HttpPut]
        [Route("users/{id}")]
        public void Put(int id, [FromBody]User user)
        {
            DataManager.UpdateUser(user);
        }
    
        // DELETE api/users/{id}
        [HttpDelete]
        [Route("users/{id}")]
        public void Delete(int id)
        {
            DataManager.DeleteUser(id);
        }
    }
}
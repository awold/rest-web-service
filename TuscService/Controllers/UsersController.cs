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

        // POST api/users
        [HttpPost]
        [Route("users")]
        public int? Post([FromBody] User user)
        {
            return DataManager.CreateUser(user);
        }

        // GET api/users/9
        [HttpGet]
        [Route("users/{id}")]
        public User Get(int id)
        {
            return DataManager.GetUsers().Where(p => p.Id == id).FirstOrDefault();
        }

        // GET api/users?sortBalance=ASC
        [HttpGet]
        [Route("users")]
        public IEnumerable<User> GetUsersByBalance(string sortBalance)
        {
            if (sortBalance.ToUpper() == "ASC")
            {
                return DataManager.GetUsers().OrderBy(p => p.Balance);
            }
            else if (sortBalance.ToUpper() == "DESC")
            {
                return DataManager.GetUsers().OrderByDescending(p => p.Balance);
            }
            else
            {
                return null;
            }
        }
        

        // PUT api/users/9
        [HttpPut]
        [Route("users/{id}")]
        public void Put(int id, [FromBody] User user)
        {
            user.Id = id;

            DataManager.UpdateUser(user);
        }

        // DELETE api/users/9
        [HttpDelete]
        [Route("users/{id}")]
        public void Delete(int id)
        {
            DataManager.DeleteUser(id);
        }
    }
}
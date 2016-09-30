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
        // GET api/products
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
            return DataManager.GetUsers().Where(p => p.Id == id).FirstOrDefault();
        }

        [HttpGet]
        [Route("users")]
        public IEnumerable<User> Get(string sortBalance)
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

        [HttpPost]
        [Route("users")]
        public int? Post([FromBody] User user)
        {
            return DataManager.CreateUser(user);
        }

        // PUT api/products/5
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
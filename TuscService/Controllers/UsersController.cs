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
        // GET api/users
        [HttpGet]
        [Route("users")]
        public IEnumerable<User> Get()
        {
            return DataManager.GetUsers();
        }

        // GET api/users/5
        [HttpGet]
        [Route("users/{id}")]
        public User Get(int id)
        {
            return DataManager.GetUsers().Where(u => u.Id == id).FirstOrDefault();
        }

        // GET api/users?sortBalance=ASC
        [HttpGet]
        [Route("users")]
        public IEnumerable<User> GetUsersOrderByBalance(string sortBalance)
        {
            if (sortBalance == "ASC")
            {
                return Get().OrderBy(u => u.Balance);
            }
            else if (sortBalance == "DESC")
            {
                return Get().OrderByDescending(u => u.Balance);
            }
            else
            {
                throw new Exception("cat");
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

        /*// GET api/users?hasStock=true
        [HttpGet]
        [Route("users")]
        public IEnumerable<Product> GetProductsWithStock(bool hasStock)
        {
            // TODO
            return null;
        }


        

        */
    }
}

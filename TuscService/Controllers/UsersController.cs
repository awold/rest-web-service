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

        // GET api/user/5
        [HttpGet]
        [Route("users/{id}")]
        public User Get(int id)
        {
            return DataManager.GetUsers().Where(p =>p.Id == id).FirstOrDefault();
        }

        // GET api/products?hasStock=true
        [HttpGet]
        [Route("products")]
        public IEnumerable<Product> GetProductsWithStock(bool hasStock)
        {
            return hasStock == true ? DataManager.GetProducts().Where(p => p.Quantity > 0) : DataManager.GetProducts();
        }
        // GET api/users sorted by Balance/
        [HttpGet]
        [Route("users/{sortBalance}")]
        public IEnumerable<User> GetUsersSortedByBalance(string sortBalance)
        {
            return sortBalance.ToUpper() =="DESC"? DataManager.GetUsers().OrderByDescending(p =>p.Balance) : DataManager.GetUsers().OrderBy(p=>p.Balance);
        }

        // POST api/users
        [HttpPost]
        [Route("users")]
        public int? Post([FromBody] User user)
        {
            return DataManager.CreateUser(user);
        }

        // PUT api/<controller>/5
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
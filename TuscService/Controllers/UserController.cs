using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TuscData;

namespace TuscService.Controllers
{
    public class UserController : ApiController
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

        // GET/transactions
        [HttpGet]
        [Route("transactions")]
        public List<Transaction> GetTransactionWithUser()
        {
            return DataManager.GetTransactions();
        }

        // GET api/users?sortBalance=ASC|DESC
        [HttpGet]
        [Route("users")]
        public IEnumerable<User> GetUsersWithSortOrder(string sortBalance)
        {
            // TODO
            if (sortBalance == "ASC")
            {
                return DataManager.GetUsers().OrderBy(b => b.Balance);
            }
            else 
            {
                return DataManager.GetUsers().OrderByDescending(b => b.Balance);
            }
        }

    }
}
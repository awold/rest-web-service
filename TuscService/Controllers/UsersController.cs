namespace TuscService.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using TuscData;

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
            return DataManager.GetUsers().Where(p => p.Id == id).FirstOrDefault();
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


        // GET api/users?sortBalance=ASC
        [HttpGet]
        [Route("users")]
        public IEnumerable<User> GetUsersSortByBalance(string sortBalance)
        {
            if (sortBalance.ToUpper() == "ASC")
            {
                return DataManager.GetUsers().OrderBy(u => u.Balance);
            }
            else if (sortBalance.ToUpper() == "DESC")
            {
                return DataManager.GetUsers().OrderByDescending(u => u.Balance);
            }
            else
                throw new ArgumentOutOfRangeException("sortBalance", "Expected either \"ASC\" or \"DESC\"");
        }
    }
}
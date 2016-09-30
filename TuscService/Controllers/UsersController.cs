using System.Collections.Generic;
using System.Linq;
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

        // GET api/users?sortBalance=ASC
        [HttpGet]
        [Route("users")]
        public IEnumerable<User> GetUsersSortedByBalance(string sortBalance)
        {
            switch (sortBalance)
            {
                case "ASC":
                    return DataManager.GetUsers().OrderBy(u => u.Balance);
                case "DESC":
                    return DataManager.GetUsers().OrderByDescending(u => u.Balance);
                default:
                    return null;
            }
        }

        // GET api/users/5
        [HttpGet]
        [Route("users/{id}")]
        public User Get(int id)
        {
            return DataManager.GetUsers().FirstOrDefault(u => u.Id == id);
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
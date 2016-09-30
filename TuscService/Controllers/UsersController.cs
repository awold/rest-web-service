using System.Collections.Generic;
using System.Linq;
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

        // GET api/users/{id}
        [HttpGet]
        [Route("users/{id}")]
        public User Get(int id)
        {
            return DataManager.GetUsers().FirstOrDefault(u => u.Id == id);
        }

        // GET api/users?sortBalance={ASC|DESC}
        [HttpGet]
        [Route("users")]
        public IEnumerable<User> GetUsersSortedByBalance(string sortBalance)
        {
            if (sortBalance == "ASC")
                return DataManager.GetUsers().OrderBy(u => u);

            return DataManager.GetUsers().OrderByDescending(u => u);
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
            user.Id = id;
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
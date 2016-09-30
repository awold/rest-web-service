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

        [HttpGet]
        [Route("users")]
        public IEnumerable<User> Get(string sortBalance)
        {
            if(!"ASC".Equals(sortBalance) && !"DESC".Equals(sortBalance))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return DataManager.GetUsers().OrderBy(u => sortBalance.Equals("ASC") ? u.Balance : -u.Balance);
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
        public int? Post([FromBody]User User)
        {
            return DataManager.CreateUser(User);
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

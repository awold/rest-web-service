using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Routing;
using TuscData;

namespace TuscService.Controllers
{
    public class ProductsController : ApiController
    {
        // GET api/products
        [HttpGet]
        [Route("products")]
        public IEnumerable<Product> Get()
        {
            return DataManager.GetProducts();
        }

        // GET api/products?hasStock=true
        [HttpGet]
        [Route("products")]
        public IEnumerable<Product> GetProductsWithStock(bool hasStock)
        {
            return hasStock
                ? DataManager.GetProducts().Where(p => p.Quantity > 0)
                : DataManager.GetProducts().Where(p => p.Quantity <= 0);
        }

        // GET api/products/5
        [HttpGet]
        [Route("products/{id}")]
        public Product Get(int id)
        {
            return DataManager.GetProducts().FirstOrDefault(p => p.Id == id);
        }

        // POST api/products
        [HttpPost]
        [Route("products")]
        public int? Post([FromBody] Product product)
        {
            return DataManager.CreateProduct(product);
        }

        // PUT api/products/5
        [HttpPut]
        [Route("products/{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            product.Id = id;

            DataManager.UpdateProduct(product);
        }

        // DELETE api/products/5
        [HttpDelete]
        [Route("products/{id}")]
        public void Delete(int id)
        {
            DataManager.DeleteProduct(id);
        }


        //GET api/users	Returns a list of all users
        [HttpGet]
        [Route("users")]
        public IEnumerable<User> GetUsers()
        {
            return DataManager.GetUsers();
        }


        //GET api/users/{id}	Returns a single user object with the matching id
        [HttpGet]
        [Route("users/{id}")]
        public User GetUser(int id)
        {
            return DataManager.GetUsers().FirstOrDefault(u => u.Id == id);
        }

        //POST /users	Creates a new User and returns the id of the newly created user
        [HttpPost]
        [Route("users")]
        public int? PostUser([FromBody] User user)
        {
            return DataManager.CreateUser(user);
        }

        //PUT /users/{id}	Update a user object (everything but ID will  be updated)
        [HttpPut]
        [Route("users/{id}")]
        public void PutUser(int id, [FromBody] User user)
        {
            user.Id = id;

            DataManager.UpdateUser(user);
        }

        //DELETE /users/{id}	Delete user by ID if it exists
        [HttpDelete]
        [Route("users/{id}")]
        public void DeleteUser(int id)
        {
            DataManager.DeleteUser(id);
        }

        // GET api/users?sortBalance={ASC|DESC}
        [HttpGet]
        [Route("users")]
        public IEnumerable<User> GetSortedBalance(string sortBalance)
        {
            switch (sortBalance)
            {
                case "ASC":
                    return DataManager.GetUsers().OrderBy(u => u.Balance);
                case "DESC":
                    return DataManager.GetUsers().OrderByDescending(u => u.Balance);
                default:
                    return DataManager.GetUsers();
            }
        }


        //GET /transactions
        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> GetTransections()
        {
            return DataManager.GetTransactions();
        }


        ////GET /transactions?startDate=2015-01-01&endDate=2016-12-31
        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> GetTransectionBetweenDates(string startdate, string enddate)
        {
            DateTime startdDateTime = DateTime.ParseExact(startdate, "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture);

            DateTime enddDateTime = DateTime.ParseExact(enddate, "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture);

            return DataManager.GetTransactions().Where(t=> t.Date <= enddDateTime && t.Date >= startdDateTime );
        }
    }
}
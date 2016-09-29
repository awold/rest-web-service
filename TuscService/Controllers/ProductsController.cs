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
            // TODO
            IEnumerable<Product> products;
            if (hasStock)
                products = DataManager.GetProducts().Where(p => p.Quantity > 0);
            else
                products = DataManager.GetProducts().Where(p => p.Quantity <= 0);

            return products;
        }

        // GET api/products/5
        [HttpGet]
        [Route("products/{id}")]
        public Product Get(int id)
        {
            return DataManager.GetProducts().Where(p => p.Id == id).FirstOrDefault();
        }

        // POST api/products
        [HttpPost]
        [Route("products")]
        public int? Post([FromBody]Product product)
        {
            return DataManager.CreateProduct(product);
        }

        // PUT api/products/5
        [HttpPut]
        [Route("products/{id}")]
        public void Put(int id, [FromBody]Product product)
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
    }
}

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
    public class TransactionsController : ApiController
    {
        // GET api/transactions
        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> Get()
        {
            return DataManager.GetTransactions();
        }

        // GET api/transactions?startDate=2015-01-01&endDate=2016-12-31	
        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> GetTransactionsWithStock(DateTime startDate, DateTime endDate)
        {
            // TODO
            return DataManager.GetTransactions().Where(p => p.Date>=startDate && p.Date<=endDate);
        }

        // GET api/transactions/5
        //[HttpGet]
        //[Route("transactions/{id}")]
        //public Product Get(int id)
        //{
        //    return DataManager.GetTransactions().Where(p => p.Id == id).FirstOrDefault();
        //}

        // POST api/transactions
        //[HttpPost]
        //[Route("transactions")]
        //public int? Post([FromBody]Transaction transaction)
        //{
        //    return DataManager.CreateTransaction(transaction);
        //}

        // PUT api/transactions/5
        //[HttpPut]
        //[Route("transactions/{id}")]
        //public void Put(int id, [FromBody]Transaction transaction)
        //{
        //    transaction.Id = id;
        //
        //    DataManager.UpdateTransaction(transaction);
        //}

        // DELETE api/transactions/5
        //[HttpDelete]
        //[Route("transactions/{id}")]
        //public void Delete(int id)
        //{
        //    DataManager.DeleteTransaction(id);
        //}
    }
}

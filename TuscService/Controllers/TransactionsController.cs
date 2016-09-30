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
        // GET api/<controller>
        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> Get()
        {
            return DataManager.GetTransactions();
        }

        // GET /transactions?startDate=2016-01-01&endDate=2016-12-31
        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> GetTransactionsInDateRange(DateTime startDate, DateTime endDate)
        {
            return DataManager.GetTransactions().Where(d=>d.Date > startDate).Where(d=>d.Date < endDate);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
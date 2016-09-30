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
        [Route("Transaction")]
        public IEnumerable<Transaction> Get()
        {
            return DataManager.GetTransactions();
        }

        // GET api/transaction/date range
        [HttpGet]
        [Route("transaction/{daterange}")]
        public IEnumerable<Transaction> GetAllTransactionsWithDateRange(DateTime startDate, DateTime endDate)
        {
            return DataManager.GetTransactions().Where(p=>p.Date>=startDate && p.Date<=endDate);
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
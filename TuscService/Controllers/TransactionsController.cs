using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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

        // GET api/transactions?startDate=DateTime&endDate=DateTime
        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> GetTransactionsInRange(DateTime startDate, DateTime endDate)
        {
            return DataManager.GetTransactions().Where(t => t.Date.CompareTo(startDate) >= 0 & t.Date.CompareTo(endDate) < 0);
        }
    }
}

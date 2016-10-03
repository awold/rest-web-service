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

        // GET api/transactions?startDate=2016-02-02&endDate=2016-12-12
        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> GetTransactionsByDateRange(DateTime startDate, DateTime endDate)
        {
            return DataManager.GetTransactions().Where(p => p.Date.Date >= startDate.Date && p.Date.Date <= endDate.Date);
        }
    }
}
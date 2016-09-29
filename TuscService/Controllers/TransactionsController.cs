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

        // GET api/transactions?hasStock=true
        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> GetTransactionsInDateRange(string startDate, string endDate)
        {
            return DataManager.GetTransactions().Where(t => t.Date >= DateTime.Parse(startDate) && t.Date <= DateTime.Parse(endDate));
        }

        
    }
}

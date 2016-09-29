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
    public class TransactionController : ApiController
    {
        // GET api/transactions
        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> Get()
        {
            return DataManager.GetTransactions();
        }

        // GET /transactions?startDate=2015-01-01&endDate=2016-12-31
        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> GetByDate()
        {
            return DataManager.GetTransactions().Where(t => t.Date.Year >= 2015 && t.Date.Year <= 2016);
        }
    }
}

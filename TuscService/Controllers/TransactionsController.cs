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
        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> Get()
        {
            return DataManager.GetTransactions();
        }

        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> Get(DateTime startDate, DateTime endDate)
        {
            return DataManager.GetTransactions().Where(t => t.Date >= startDate && t.Date <= endDate);
        }

    }
}

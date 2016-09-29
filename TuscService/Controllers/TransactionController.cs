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

        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> Get()
        {
            return DataManager.GetTransactions();
        }


        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> GetTransactionbetweendates(DateTime startDate, DateTime endDate)
        {
            return DataManager.GetTransactions().Where(j => j.Date >= startDate && j.Date <= endDate).ToList();
        }
    }
}

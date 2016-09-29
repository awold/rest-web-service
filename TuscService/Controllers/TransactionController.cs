using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

        // GET api/transactions
        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> GetTransactionsByDate(DateTime dt1, DateTime dt2)
        {
            return DataManager.GetTransactions().Where(r => r.Date >= dt1 && r.Date <= dt2);
        }
    }
}

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
        // GET api/<controller>
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
            return DataManager.GetTransactions().Where(tr => tr.Date >= startDate && tr.Date <= endDate);
        }

    }
}
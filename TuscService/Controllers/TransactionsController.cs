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
        // GET api/products
        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> Get()
        {
            return DataManager.GetTransactions();
        }


        // GET api/<controller>/5
        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> Get(DateTime startDate, DateTime endDate)
        {
            return DataManager.GetTransactions().Where(p => p.Date >= startDate && p.Date <= endDate);
        }
    }
}
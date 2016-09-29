namespace TuscService.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using TuscData;

    public class TransactionsController : ApiController
    {
        // GET api/products
        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> Get()
        {
            return DataManager.GetTransactions();
        }
        
        // GET api/users?sortBalance=ASC
        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> GetTransactionsByDate(DateTime startDate, DateTime endDate)
        {
            return DataManager.GetTransactions().Where(t => (t.Date.Date >= startDate.Date && t.Date.Date <= endDate.Date));
        }
    }
}

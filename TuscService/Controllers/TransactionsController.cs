using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> Get(DateTime startDate, DateTime endDate)
        {
            if (startDate != null && endDate != null)
            {
                return DataManager.GetTransactions().Where(t => t.Date >= startDate && t.Date <= endDate);
            }
            else if (startDate != null && endDate == null)
            {
                return DataManager.GetTransactions().Where(t => t.Date >= startDate);
            }
            else if (startDate == null && endDate != null)
            {
                return DataManager.GetTransactions().Where(t => t.Date <= endDate);
            }
            else
            {
                return DataManager.GetTransactions();
            }
        }
    }
}
﻿using System;
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

        // GET api/transactions?startDate=2015-01-01&endDate=2016-12-31
        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> GetTransactionsInDateRange(DateTime startDate, DateTime endDate)
        {
            return DataManager.GetTransactions().Where(t => t.Date > startDate && t.Date < endDate);
        }
    }
}

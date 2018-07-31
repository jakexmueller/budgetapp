using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using budgetapp.Models;

namespace budgetapp.Controllers
{
    public class StocksController : Controller
    {
        // GET: Stocks
        public ActionResult Index()
        {
            return View();
        }

        // GET: Stock Quote
        //public ActionResult GetExxonStockQuote(string XOM)
        //{
        //    AlphaVantageAPI alphaVantageAPI = alphaVantageAPI.GetStockDataAsync(XOM);
        //}

    }
}
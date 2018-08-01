using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using budgetapp.Models;
using Newtonsoft.Json.Linq;

namespace budgetapp.Controllers
{
    public class StocksController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Stocks
        public ActionResult Index(Stock stock)
        {
            //var x = 5;

            return View(stock);
        }

        //  GET: Stock Quote
        public async Task<ActionResult> GetStockQuote(string symbol)
        {
            symbol = "XOM";
            AlphaVantageAPI alphaVantageAPI = new AlphaVantageAPI(MyKeys.ALPHA_VANTAGE_API_KEY);
            var test = await alphaVantageAPI.GetStockDataAsync(symbol);
            var jo = JObject.Parse(test);

            DateTime today = DateTime.Today;
            DateTime oneMonthAgo = GetLastBusinessDayPreviousMonth(today);
            DateTime twoMonthsAgo = GetLastBusinessDayPreviousMonth(oneMonthAgo);
            DateTime threeMonthsAgo = GetLastBusinessDayPreviousMonth(twoMonthsAgo);
            DateTime fourMonthsAgo = GetLastBusinessDayPreviousMonth(threeMonthsAgo);
            DateTime fiveMonthsAgo = GetLastBusinessDayPreviousMonth(fourMonthsAgo);
            DateTime sixMonthsAgo = GetLastBusinessDayPreviousMonth(fiveMonthsAgo);

            string todayString = today.ToString("yyyy-MM-dd");
            string oneMonthAgoString = oneMonthAgo.ToString("yyyy-MM-dd");
            string twoMonthsAgoString = twoMonthsAgo.ToString("yyyy-MM-dd");
            string threeMonthsAgoString = threeMonthsAgo.ToString("yyyy-MM-dd");
            string fourMonthsAgoString = fourMonthsAgo.ToString("yyyy-MM-dd");
            string fiveMonthsAgoString = fiveMonthsAgo.ToString("yyyy-MM-dd");
            string sixMonthsAgoString = sixMonthsAgo.ToString("yyyy-MM-dd");

            var stockPriceToday = jo["Monthly Time Series"][todayString]["4. close"];
            var stockPriceOneMonthAgo = jo["Monthly Time Series"][oneMonthAgoString]["4. close"];
            var stockPriceTodayTwoMonthsAgo = jo["Monthly Time Series"][twoMonthsAgoString]["4. close"];
            var stockPriceTodayThreeMonthsAgo = jo["Monthly Time Series"][threeMonthsAgoString]["4. close"];
            var stockPriceTodayFourMonthsAgo = jo["Monthly Time Series"][fourMonthsAgoString]["4. close"];
            var stockPriceTodayFiveMonthsAgo = jo["Monthly Time Series"][fiveMonthsAgoString]["4. close"];
            var stockPriceTodaySixMonthsAgo = jo["Monthly Time Series"][sixMonthsAgoString]["4. close"];

            Stock stock = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Stock>(test);

            stock.CurrentPrice = stockPriceToday.ToObject<double>();
            stock.OneMonthAgoPrice = stockPriceOneMonthAgo.ToObject<double>();
            stock.TwoMonthsAgoPrice = stockPriceTodayTwoMonthsAgo.ToObject<double>();
            stock.ThreeMonthsAgoPrice = stockPriceTodayThreeMonthsAgo.ToObject<double>();
            stock.FourMonthsAgoPrice = stockPriceTodayFourMonthsAgo.ToObject<double>();
            stock.FiveMonthsAgoPrice = stockPriceTodayFiveMonthsAgo.ToObject<double>();
            stock.SixMonthsAgoPrice = stockPriceTodaySixMonthsAgo.ToObject<double>();

            return RedirectToAction("Index", stock);
        }

        //GET: ChooseStock
        public ActionResult ChooseStock()
        {
            return View();
        }

        // Retrieves Last Business Day of previous month
        public DateTime GetLastBusinessDayPreviousMonth (DateTime date)
        {
            var holidays = new List<DateTime>
            {
                new DateTime(2018, 1, 1),
                new DateTime(2018, 1, 15),
                new DateTime(2018, 2, 19),
                new DateTime(2018, 3, 30),
                new DateTime(2018, 5, 28),
                new DateTime(2018, 6, 4),
                new DateTime(2018, 9, 3),
                new DateTime(2018, 11, 22),
                new DateTime(2018, 12, 25)
            };

            var firstDayCurrentMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayPreviousMonth = firstDayCurrentMonth.AddDays(-1);
            if (lastDayPreviousMonth.DayOfWeek == DayOfWeek.Saturday)
            {
                lastDayPreviousMonth = lastDayPreviousMonth.AddDays(-1);
            }
            if(lastDayPreviousMonth.DayOfWeek == DayOfWeek.Sunday)
            {
                lastDayPreviousMonth = lastDayPreviousMonth.AddDays(-2);
            }
            if (holidays.Contains(lastDayPreviousMonth))
            {
                lastDayPreviousMonth = lastDayPreviousMonth.AddDays(-1);
            }

            return lastDayPreviousMonth;
        }


    }
}
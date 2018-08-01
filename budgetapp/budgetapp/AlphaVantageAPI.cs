using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace budgetapp
{
    public class AlphaVantageAPI
    {
        public string ApiKey { get; set; }

        public AlphaVantageAPI (string apikey)
        {
            ApiKey = apikey;
        }


        public async Task<string> GetStockDataAsync(string symbol)
        {
            using (var client = new HttpClient())
            {
                var url = $"https://www.alphavantage.co/query?function=TIME_SERIES_MONTHLY&symbol={symbol}&apikey={MyKeys.ALPHA_VANTAGE_API_KEY}&datatype=json";
                
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                }

            }
            return null;
        }

    }
}
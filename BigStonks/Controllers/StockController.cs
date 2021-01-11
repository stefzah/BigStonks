using BigStonks.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BigStonks.Controllers
{
    public class StockController : Controller
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        public ActionResult Index(string searching)
        {
            var stocks = ctx.Stocks.Where(x => x.Ticker.Contains(searching) || searching == null);
            //foreach(var stock in stocks)
            //{
            //    AVConnection AVC = new AVConnection();
            //    AVC.GetBasicStockInfo(stock, ctx);
            //}
            //ctx.SaveChanges();
            return View(stocks.ToList());
        }

    }

    public class AVConnection
    {
        private readonly string _apiKey;

        public AVConnection()
        {
            this._apiKey = "M5ADCMBCGVGMTN3Y";
        }

        public void GetBasicStockInfo(Stock stock, ApplicationDbContext ctx)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://" + $@"www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={stock.Ticker}&apikey={this._apiKey}");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Console.WriteLine(resp);
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();

            JObject jObject = JObject.Parse(results);
            JToken jStock = jObject["Global Quote"];
           
            if (jStock != null)
            {
            double Open = Convert.ToDouble((string)jStock["02. open"]);
            double High = Convert.ToDouble((string)jStock["03. high"]);
            double Low = Convert.ToDouble((string)jStock["04. low"]);
            double Price = Convert.ToDouble((string)jStock["05. price"]);
            int Volume = Convert.ToInt32((string)jStock["06. volume"]);
            double PrevClose = Convert.ToDouble((string)jStock["08. previous close"]);
            double Change = Convert.ToDouble((string)jStock["09. change"]);
            string ChangePercentStr = (string)jStock["10. change percent"];
            ChangePercentStr = ChangePercentStr.Remove(ChangePercentStr.Length - 1);
            double ChangePercent = Convert.ToDouble(ChangePercentStr);

            
                stock.Open = Open;
                stock.High = High;
                stock.Low = Low;
                stock.Price = Price;
                stock.Volume = Volume;
                stock.PrevClose = PrevClose;
                stock.Change = Change;
                stock.ChangePercent = ChangePercent;
            }
        }

        public void getDetailedStockInfo(Stock stock, ApplicationDbContext ctx)
        {

            GetBasicStockInfo(stock, ctx);

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://" + $@"www.alphavantage.co/query?function=OVERVIEW&symbol={stock.Ticker}&apikey={this._apiKey}");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Console.WriteLine(resp);
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();

            JObject jStock = JObject.Parse(results);


            string Name = ((string)jStock["Name"]);
            string Description = ((string)jStock["Description"]);
            string Excange = ((string)jStock["Excange"]);
            string Currency = ((string)jStock["Currency"]);
            string Country = ((string)jStock["Country"]);
            string Sector = ((string)jStock["Sector"]);
            double PERatio = Convert.ToDouble((string)jStock["PERatio"]);
            double PEGRatio = Convert.ToDouble((string)jStock["PEGRatio"]);
            double BookValue = Convert.ToDouble((string)jStock["BookValue"]);
            double DividendPerShare = Convert.ToDouble((string)jStock["DividendPerShare"]);
            double DividendYield = Convert.ToDouble((string)jStock["DividendYield"]);
            double EPS = Convert.ToDouble((string)jStock["EPS"]);
            double RevenuePerShareTTM = Convert.ToDouble((string)jStock["RevenuePerShareTTM"]);
            double ProfitMargin = Convert.ToDouble((string)jStock["ProfitMargin"]);

        }
    }
}
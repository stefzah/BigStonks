using BigStonks.Models;
using Microsoft.AspNet.Identity;
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

        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Stock stock = ctx.Stocks.Find(id);
                if (stock != null)
                {
                    AVConnection AVC = new AVConnection();
                    AVC.GetDetailedStockInfo(stock, ctx);
                    ctx.SaveChanges();
                    return View(stock);
                }
                return HttpNotFound("Couldn't find the book with id " + id.ToString() + "!");
            }
            return HttpNotFound("Missing stock id parameter!");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Buy(int? id, int ammount)
        {
            if (id.HasValue)
            {
                Stock stock = ctx.Stocks.Find(id);
                if (stock != null)
                {
                    var userId = User.Identity.GetUserId();
                    var user = ctx.Users.Find(userId);

                    if (ammount != null)
                    {

                        if (ammount <= 0)
                        {
                            ViewData["Error"] = "The ammount must be grater than 0";
                        }
                        else if (ammount * stock.Price > user.Portofolio.AvailableFunds)
                        {
                            ViewData["Error"] = "You have unsuffisient funds to buy so many stocks";
                        }
                        else
                        {
                            Order order = new Order { Filled = true, Ammount = ammount, Price = stock.Price, Total = stock.Price * ammount, TimeFilled = DateTime.Now, TimeOrdered = DateTime.Now, Type = "Buy", Stock = stock };
                            user.Portofolio.Orders.Add(order);
                            Position position = new Position { Stock = stock, PurchaseDate = order.TimeFilled, Ammount = order.Ammount, InitialPrice = order.Price, InitialCost = order.Total };
                            user.Portofolio.Positions.Add(position);
                            user.Portofolio.AvailableFunds -= order.Total;
                            ctx.SaveChanges();
                            ViewData["Success"] = "You succesfully baught "+ammount.ToString()+" shares of "+stock.Ticker;
                        }
                    }
                    return View("Details", stock);
                }
                return HttpNotFound("Couldn't find the stock with id " + id.ToString() + "!");
            }
            return HttpNotFound("Missing stock id parameter!");
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
            ctx.SaveChanges();
        }
        public void GetDetailedStockInfo(Stock stock, ApplicationDbContext ctx)
        {

            GetBasicStockInfo(stock, ctx);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://" + $@"www.alphavantage.co/query?function=OVERVIEW&symbol={stock.Ticker}&apikey={this._apiKey}");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();

            JToken jStock = JObject.Parse(results);

            if (jStock["Name"] != null)
            {
                string Name = ((string)jStock["Name"]);
                string Description = ((string)jStock["Description"]);
                string Excange = ((string)jStock["Excange"]);
                string Currency = ((string)jStock["Currency"]);
                string Country = ((string)jStock["Country"]);
                string Sector = ((string)jStock["Sector"]);
                double BookValue = Convert.ToDouble((string)jStock["BookValue"]);
                double EPS = Convert.ToDouble((string)jStock["EPS"]);
                double RevenuePerShareTTM = Convert.ToDouble((string)jStock["RevenuePerShareTTM"]);
                double ProfitMargin = Convert.ToDouble((string)jStock["ProfitMargin"]);

                stock.Name = Name;
                stock.Description = Description;
                stock.Exchange = Excange;
                stock.Currency = Currency;
                stock.Country = Country;
                stock.Sector = Sector;
                stock.BookValue = BookValue;
                stock.EPS = EPS;
                stock.RevenuePerShareTTM = RevenuePerShareTTM;
                stock.ProfitMargin = ProfitMargin;
            }

            ctx.SaveChanges();
        }
    }
}
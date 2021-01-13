using BigStonks.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigStonks.Controllers
{
    public class PositionController : Controller
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        // GET: Position
        [Authorize]
        public ActionResult Sell(int? id)
        {
            if (id.HasValue)
            {
                var position = ctx.Positions.Find(id);
                if (position != null)
                {

                    var userId = User.Identity.GetUserId();
                    var user = ctx.Users.Find(userId);
                    user.Portofolio.AvailableFunds += position.Ammount * position.Stock.Price;
                    user.Portofolio.AccountValue += position.Ammount * position.Stock.Price - position.Ammount * position.InitialPrice;
                    var stock = position.Stock;
                    Order order = new Order { Filled = true, Ammount = position.Ammount, Price = stock.Price, Total = stock.Price * position.Ammount, TimeFilled = DateTime.Now, TimeOrdered = DateTime.Now, Type = "Sell", Stock = stock };
                    ctx.Orders.Add(order);
                    ctx.Positions.Remove(position);
                    user.Portofolio.Orders.Add(order);
                    ctx.SaveChanges();
                    return Redirect(Request.UrlReferrer.PathAndQuery);
                }
                return HttpNotFound("Couldn't find the position with id " + id.ToString() + "!");
            }
            return HttpNotFound("Missing position id parameter!");
        }
    }
}
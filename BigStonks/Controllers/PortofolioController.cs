using BigStonks.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigStonks.Controllers
{
    public class PortofolioController : Controller
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        // GET: Portofolio
        [Authorize]
        public ActionResult Details()
        {
            var userId = User.Identity.GetUserId();
            var user = ctx.Users.Find(userId);
            foreach(var position in user.Portofolio.Positions)
            {
                AVConnection AVC = new AVConnection();
                AVC.GetBasicStockInfo(position.Stock, ctx);
            }
            return View(user.Portofolio);
        }
    }
}
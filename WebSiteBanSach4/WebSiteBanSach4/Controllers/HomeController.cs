using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanSach4.Models;
namespace WebSiteBanSach4.Controllers
{
    public class HomeController : Controller
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public ActionResult Index()
        {
            return View(db.Saches.ToList());
        }
    }
}
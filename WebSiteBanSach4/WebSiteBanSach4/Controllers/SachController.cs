using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanSach4.Models;
namespace WebSiteBanSach4.Controllers
{
    public class SachController : Controller
    {
        // GET: Sach
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public PartialViewResult SachMoiPartial()
        {
            var lstSachMoi = db.Saches.Take(3).ToList();
            return PartialView(lstSachMoi);
        }
    }
}
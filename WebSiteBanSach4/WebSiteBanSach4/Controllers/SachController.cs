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

        public ViewResult XemChiTiet(int MaSach=0)
        {
            Sach sach = db.Saches.SingleOrDefault(x=>x.MaSach==MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }
    }
}
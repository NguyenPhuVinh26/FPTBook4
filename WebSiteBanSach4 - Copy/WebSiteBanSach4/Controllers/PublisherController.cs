using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanSach4.Models;
namespace WebSiteBanSach4.Controllers
{
    public class PublisherController : Controller
    {
        // GET: NhaXuatBan
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();

        public PartialViewResult PublisherPartial()
        {
            return PartialView(db.NhaXuatBans.Take(10).OrderBy(x => x.TenNXB).ToList());
        }
        public ViewResult BookPublisher(int MaNXB)
        { 
            NhaXuatBan nxb = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if(nxb==null)
            {
                Response.StatusCode=404;
                return null;
            }
            List<Sach> lstsach = db.Saches.Where(n=>n.MaNXB==MaNXB).OrderBy(n=>n.GiaBan).ToList();
            if(lstsach.Count==0)
            {
                ViewBag.Sach = "There are no books on this topic";
            }
            return View(lstsach);
        }
        public ViewResult ThemePublisher()
        {
            return View(db.NhaXuatBans.ToList());
        }
     }
}

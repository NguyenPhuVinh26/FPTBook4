using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanSach4.Models;
using PagedList;
using PagedList.Mvc;
namespace WebSiteBanSach4.Controllers
{
    public class SearchController : Controller
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        [HttpPost]
        // GET: TimKiem
        public ActionResult SearchResult(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<Sach> lstKQTK = db.Saches.Where(n => n.TenSach.Contains(sTuKhoa)).ToList();
            int pageNumber = (page ?? 1);
            int pageSize = 9;
            
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "No product found";
                return View(db.Saches.OrderBy(n => n.TenSach).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Found" + lstKQTK.Count + "results";
            return View(lstKQTK.OrderBy(n=>n.TenSach).ToPagedList(pageNumber,pageSize));
        }
      
        [HttpGet]
        // GET: TimKiem
        public ActionResult SearchResult(string sTuKhoa, int? page)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<Sach> lstKQTK = db.Saches.Where(n => n.TenSach.Contains(sTuKhoa)).ToList();
            int pageNumber = (page ?? 1);
            int pageSize = 9;
            
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "No product found";
                return View(db.Saches.OrderBy(n => n.TenSach).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Found" + lstKQTK.Count + "results";
            return View(lstKQTK.OrderBy(n=>n.TenSach).ToPagedList(pageNumber,pageSize));
        }
    }
}
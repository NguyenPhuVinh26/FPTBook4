using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanSach4.Models;
using PagedList.Mvc;
using PagedList;

namespace WebSiteBanSach4.Controllers
{
    public class QuanLyTacGiaController : Controller
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        // GET: QuanLyTacGia
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.TacGias.ToList().OrderBy(n=>n.TenTacGia).ToPagedList(pageNumber,pageSize));
        }

        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(TacGia tacgia)
        {
            if (ModelState.IsValid)
            {
                db.TacGias.Add(tacgia);
                db.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public ActionResult ChinhSua(int MaTacGia)
        {
            TacGia tacgia = db.TacGias.SingleOrDefault(n => n.MaTacGia == MaTacGia);
            if (tacgia == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tacgia);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(TacGia tacgia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tacgia).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult HienThi(int MaTacGia)
        {
            TacGia tacgia = db.TacGias.SingleOrDefault(n => n.MaTacGia == MaTacGia);
            if (tacgia == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tacgia);
        }

        [HttpGet]
        public ActionResult Xoa(int MaTacGia)
        {
            TacGia tacgia = db.TacGias.SingleOrDefault(n => n.MaTacGia == MaTacGia);
            if (tacgia == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tacgia);
        }

        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaTacGia)
        {
            TacGia tacgia = db.TacGias.SingleOrDefault(n => n.MaTacGia == MaTacGia);
            if (tacgia == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.TacGias.Remove(tacgia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    
    }
}
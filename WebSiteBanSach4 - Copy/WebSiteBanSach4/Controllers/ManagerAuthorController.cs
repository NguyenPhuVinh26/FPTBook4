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
    public class ManagerAuthorController : Controller
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
        public ActionResult Add()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("Login", "Customer");
            }
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(TacGia tacgia)
        {
            if (ModelState.IsValid)
            {
                db.TacGias.Add(tacgia);
                db.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int MaTacGia)
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("Login", "Customer");
            }
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
        public ActionResult Edit(TacGia tacgia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tacgia).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult Details(int MaTacGia)
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("Login", "Customer");
            }
            TacGia tacgia = db.TacGias.SingleOrDefault(n => n.MaTacGia == MaTacGia);
            if (tacgia == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tacgia);
        }

        [HttpGet]
        public ActionResult Delete(int MaTacGia)
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("Login", "Customer");
            }
            TacGia tacgia = db.TacGias.SingleOrDefault(n => n.MaTacGia == MaTacGia);
            if (tacgia == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tacgia);
        }

        [HttpPost, ActionName("Delete")]
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
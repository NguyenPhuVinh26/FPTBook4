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
    public class ManagerCategoryController : Controller
    {
        // GET: QuanLyLoai
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.ChuDes.ToList().OrderBy(n=>n.TenChuDe).ToPagedList(pageNumber,pageSize));
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
        public ActionResult Add(ChuDe chude)
        {
            if (ModelState.IsValid)
            {
                db.ChuDes.Add(chude);
                db.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int MaChuDe)
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("Login", "Customer");
            }
            ChuDe chude = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (chude == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chude);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ChuDe chude)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chude).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult Details(int MaChuDe)
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("Login", "Customer");
            }
            ChuDe chude = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (chude == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chude);
        }
        [HttpGet]
        public ActionResult Delete(int MaChuDe)
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("Login", "Customer");
            }
            ChuDe chude = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (chude == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chude);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult XacNhanXoa(int MaChuDe)
        {
            ChuDe chude = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (chude == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.ChuDes.Remove(chude);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
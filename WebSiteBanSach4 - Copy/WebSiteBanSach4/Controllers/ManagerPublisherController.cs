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
    public class ManagerPublisherController : Controller
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        // GET: QuanLyNXB
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.NhaXuatBans.ToList().OrderBy(n => n.TenNXB).ToPagedList(pageNumber, pageSize));
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
        public ActionResult Add(NhaXuatBan nhaxuatban)
        {
            if (ModelState.IsValid)
            {
                db.NhaXuatBans.Add(nhaxuatban);
                db.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int MaNXB)
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("Login", "Customer");
            }
            NhaXuatBan nhaxuatban = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (nhaxuatban == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nhaxuatban);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(NhaXuatBan nhaxuatban)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhaxuatban).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult Details(int MaNXB)
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("Login", "Customer");
            }
            NhaXuatBan nhaxuatban = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (nhaxuatban == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nhaxuatban);
        }

        [HttpGet]
        public ActionResult Delete(int MaNXB)
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("Login", "Customer");
            }
            NhaXuatBan nhaxuatban = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (nhaxuatban == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nhaxuatban);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult XacNhanXoa(int MaNXB)
        {
            NhaXuatBan nhaxuatban = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (nhaxuatban == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.NhaXuatBans.Remove(nhaxuatban);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
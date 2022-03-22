using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanSach4.Models;

namespace WebSiteBanSach4.Controllers
{
    public class CustomerController : Controller
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();

        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult Register(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(kh);
                db.SaveChanges();          
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            string sTaiKhoan = f["txtTaiKhoan"].ToString();
            string sMatKhau = f.Get("txtMatKhau").ToString();
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            if (kh != null)
            {
                ViewBag.ThongBao = "Logged in successfully !";
                Session["TaiKhoan"] = kh;
                return View();
            }
            ViewBag.ThongBao = "Username or password is incorrect !";
            return View();

        }

    }
}
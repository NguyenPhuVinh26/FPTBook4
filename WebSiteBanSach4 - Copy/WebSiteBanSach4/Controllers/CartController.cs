using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanSach4.Models;
namespace WebSiteBanSach4.Controllers
{
    public class CartController : Controller
    {
        // GET: GioHang
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["Cart"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["Cart"] = lstGioHang;
            }
            return lstGioHang;
        }
        public ActionResult ThemGioHang(int iMaSach, string strURL)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == iMaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.Find(n => n.iMaSach == iMaSach);
            if (sanpham == null)
            {
                sanpham = new GioHang(iMaSach);
                lstGioHang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);
            }
        }
        /*Update Cart*/
        public ActionResult CapNhatGioHang(int iMaSP, FormCollection f)
        {
            //Check ID product
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == iMaSP);
            //If you get the wrong product code, will return an error message.
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Take out cart from session
            List<GioHang> lstGioHang = LayGioHang();
            //Check product exists in Session ["GioHang"]
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMaSach == iMaSP);
            //If the code exists, will fix the quantity.
            if (sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("Cart");
        }
        /*Delete Cart*/
        public ActionResult XoaGioHang(int iMaSP)
        {
            //Check ID product
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == iMaSP);
            //If you get the wrong product code, will return an error message.
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMaSach == iMaSP);
            if (sanpham != null)
            {
                lstGioHang.RemoveAll(n => n.iMaSach == iMaSP);
            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Cart");
        }
        /*Build a shopping cart page*/
        public ActionResult Cart()
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();

            return View(lstGioHang);
        }

        /*Calculate the total amount and the total money*/
        /*Calculate the total amount*/
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["Cart"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        /*Calculate the total money*/
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = Session["Cart"] as List<GioHang>;
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.ThanhTien);
            }
            return dTongTien;
        }
        /*Create Partial for the shopping cart.*/

        public ActionResult CartPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        /*Build 1 view for user to edit cart*/
        public ActionResult EditCart()
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }
        // Oreder
        [HttpPost]
        public ActionResult DatHang()
        {
            if(Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("Login","Customer");
            }

            if (Session["Cart"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            DonHang ddh = new DonHang();
            KhachHang kh = (KhachHang)Session["TaiKhoan"];
            List<GioHang> gh = LayGioHang();
            ddh.MaKH = kh.MaKH;
            ddh.NgayDat = DateTime.Now;
            db.DonHangs.Add(ddh);
            db.SaveChanges();

            foreach (var item in gh)
            {
                ChiTietDonHang ctDH = new ChiTietDonHang();
                ctDH.MaDonHang = ddh.MaDonHang;
                ctDH.MaSach = item.iMaSach;
                ctDH.SoLuong = item.iSoLuong;
                db.ChiTietDonHangs.Add(ctDH);
            }
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}
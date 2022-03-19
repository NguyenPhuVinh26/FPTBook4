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
    public class QuanLyLoaiController : Controller
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
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(ChuDe chude)
        {
            if (ModelState.IsValid)
            {
                db.ChuDes.Add(chude);
                db.SaveChanges();
            }
            return View();
        }
    }
}
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
    }
}
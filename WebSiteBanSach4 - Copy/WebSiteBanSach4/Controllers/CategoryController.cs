﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanSach4.Models;
namespace WebSiteBanSach4.Controllers
{
    public class CategoryController : Controller
    {
        // GET: ChuDe
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public ActionResult CategoryPartial()
        {
            return PartialView(db.ChuDes.Take(5).ToList());
        }
        public ViewResult BookCategory(int MaChuDe)
        {
            ChuDe cd = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if(cd==null)
            {
                Response.StatusCode=404;
                return null;
            }
            List<Sach> lstsach = db.Saches.Where(n=>n.MaChuDe==MaChuDe).OrderBy(n=>n.GiaBan).ToList();
            if(lstsach.Count==0)
            {
                ViewBag.Sach = "There are no books on this topic";
            }
            return View(lstsach);
        }
        public ViewResult ThemeCategory()
        {
            return View(db.ChuDes.ToList());
        }
    }
}
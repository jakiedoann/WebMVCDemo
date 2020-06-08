using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVCDemo.Models;

namespace WebMVCDemo.Controllers
{
    public class ProductController : Controller
    {
        ShopGiayOnlineEntities db = new ShopGiayOnlineEntities();
        // GET: Product
        public ActionResult Index(string meta)
        {
            var v = from t in db.NhomSanPhams
                    where t.Meta == meta
                    select t;
            return View(v.FirstOrDefault());
        }

        public ActionResult Detail(int id)
        {
            ViewBag.meta = "san-pham";
            var v = from t in db.SanPhams
                    where t.MaSP == id
                    select t;
            return View(v.FirstOrDefault());
        }

        public ActionResult getProductOfCategory(int id, string metatitle)
        {
            ViewBag.meta = "san-pham";

            var v = from t in db.SanPhams.Take(4)
                    where t.MaNhom == id && t.Hide == false
                    select t;
            return PartialView(v.ToList());
        }

    }
}
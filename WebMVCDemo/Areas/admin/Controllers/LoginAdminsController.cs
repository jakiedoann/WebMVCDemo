using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMVCDemo.Models;

namespace WebMVCDemo.Areas.admin.Controllers
{
    public class LoginAdminsController : Controller
    {
        private ShopGiayOnlineEntities db = new ShopGiayOnlineEntities();

        // GET: admin/LoginAdmins
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string pass)
        {
            LoginAdmin loginAdmin = db.LoginAdmins.Find(username);
            if (loginAdmin.Username == "TienNguyen")
            {
                if(loginAdmin.Password == "331212tt")
                {
                    return View("Đăng Nhập Thành Công", "Index", "Default");
                }
                else
                {
                    return View("Sai mật khẩu!...");
                }
            }
            else
            {
                return View("Không tồn lại tên này!...");
            }
        }
        public ActionResult Manage()
        {
            return View(db.LoginAdmins.ToList());
        }

        // GET: admin/LoginAdmins/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginAdmin loginAdmin = db.LoginAdmins.Find(id);
            if (loginAdmin == null)
            {
                return HttpNotFound();
            }
            return View(loginAdmin);
        }

        // GET: admin/LoginAdmins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/LoginAdmins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "username,password")] LoginAdmin loginAdmin)
        {
            if (ModelState.IsValid)
            {
                db.LoginAdmins.Add(loginAdmin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loginAdmin);
        }

        // GET: admin/LoginAdmins/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginAdmin loginAdmin = db.LoginAdmins.Find(id);
            if (loginAdmin == null)
            {
                return HttpNotFound();
            }
            return View(loginAdmin);
        }

        // POST: admin/LoginAdmins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "username,password")] LoginAdmin loginAdmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginAdmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loginAdmin);
        }

        // GET: admin/LoginAdmins/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginAdmin loginAdmin = db.LoginAdmins.Find(id);
            if (loginAdmin == null)
            {
                return HttpNotFound();
            }
            return View(loginAdmin);
        }

        // POST: admin/LoginAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoginAdmin loginAdmin = db.LoginAdmins.Find(id);
            db.LoginAdmins.Remove(loginAdmin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

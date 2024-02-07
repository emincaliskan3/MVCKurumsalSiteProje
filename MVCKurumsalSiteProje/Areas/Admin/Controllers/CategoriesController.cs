using MVCKurumsalSiteProje.Data;
using MVCKurumsalSiteProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MVCKurumsalSiteProje.Areas.Admin.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        DatabaseContext context = new DatabaseContext();
        // GET: Admin/Categories
        public ActionResult Index()
        {
            return View(context.Categories.ToList());
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        [HttpPost]
        public ActionResult Create(Category category, HttpPostedFileBase Image)
        {
            category.CreateDate = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return View(category);

            }
            try
            {
                if (Image != null)
                {
                    category.Image = Image.FileName;
                    Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                }
                // TODO: Add insert logic here
                context.Categories.Add(category);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = context.Categories.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);

        }

        // POST: Admin/Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category, HttpPostedFileBase Image)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            try
            {
                if (Image != null)
                {
                    category.Image = Image.FileName;
                    Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                }
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;

                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = context.Categories.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Category collection)
        {
            try
            {
                var data = context.Categories.Find(id);
                context.Categories.Remove(data);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

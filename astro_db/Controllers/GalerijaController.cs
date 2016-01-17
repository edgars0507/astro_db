using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using astro_db.Models;

namespace astro_db.Controllers
{
    public class GalerijaController : Controller
    {
        private AstroEntities1Galerija db = new AstroEntities1Galerija();

        // GET: /Galerija/
        public ActionResult Index()
        {
            return View(db.Atteli.ToList());
        }

        // GET: /Galerija/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atteli atteli = db.Atteli.Find(id);
            if (atteli == null)
            {
                return HttpNotFound();
            }
            return View(atteli);
        }

        // GET: /Galerija/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Galerija/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nosaukums,Path")] Atteli atteli)
        {
            if (ModelState.IsValid)
            {
                db.Atteli.Add(atteli);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(atteli);
        }

        // GET: /Galerija/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atteli atteli = db.Atteli.Find(id);
            if (atteli == null)
            {
                return HttpNotFound();
            }
            return View(atteli);
        }

        // POST: /Galerija/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nosaukums,Path")] Atteli atteli)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atteli).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(atteli);
        }

        // GET: /Galerija/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atteli atteli = db.Atteli.Find(id);
            if (atteli == null)
            {
                return HttpNotFound();
            }
            return View(atteli);
        }

        // POST: /Galerija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atteli atteli = db.Atteli.Find(id);
            db.Atteli.Remove(atteli);
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

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
    public class LidaparatiController : Controller
    {
        private LidaparatiEntity db = new LidaparatiEntity();

        // GET: /Lidaparati/
        public ActionResult Index()
        {
            return View(db.Lidaparati.ToList());
        }

        // GET: /Lidaparati/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lidaparati lidaparati = db.Lidaparati.Find(id);
            if (lidaparati == null)
            {
                return HttpNotFound();
            }
            return View(lidaparati);
        }

        // GET: /Lidaparati/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Lidaparati/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nosaukums,Apraksts")] Lidaparati lidaparati)
        {
            if (ModelState.IsValid)
            {
                db.Lidaparati.Add(lidaparati);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lidaparati);
        }

        // GET: /Lidaparati/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lidaparati lidaparati = db.Lidaparati.Find(id);
            if (lidaparati == null)
            {
                return HttpNotFound();
            }
            return View(lidaparati);
        }

        // POST: /Lidaparati/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nosaukums,Apraksts")] Lidaparati lidaparati)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lidaparati).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lidaparati);
        }

        // GET: /Lidaparati/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lidaparati lidaparati = db.Lidaparati.Find(id);
            if (lidaparati == null)
            {
                return HttpNotFound();
            }
            return View(lidaparati);
        }

        // POST: /Lidaparati/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lidaparati lidaparati = db.Lidaparati.Find(id);
            db.Lidaparati.Remove(lidaparati);
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

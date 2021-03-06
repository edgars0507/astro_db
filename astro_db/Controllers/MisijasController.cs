﻿using System;
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
    public class MisijasController : Controller
    {
        private MisijasEntities db = new MisijasEntities();

        // GET: /Misijas/
        public ActionResult Index()
        {
            return View(db.Misijas.ToList());
        }

        // GET: /Misijas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Misijas misijas = db.Misijas.Find(id);
            if (misijas == null)
            {
                return HttpNotFound();
            }
            return View(misijas);
        }

        // GET: /Misijas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Misijas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nosaukums,Datums,Valsts,Merkis,Rezultats,Apraksts")] Misijas misijas)
        {
            if (ModelState.IsValid)
            {
                db.Misijas.Add(misijas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(misijas);
        }

        // GET: /Misijas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Misijas misijas = db.Misijas.Find(id);
            if (misijas == null)
            {
                return HttpNotFound();
            }
            return View(misijas);
        }

        // POST: /Misijas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nosaukums,Datums,Valsts,Merkis,Rezultats,Apraksts")] Misijas misijas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(misijas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(misijas);
        }

        // GET: /Misijas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Misijas misijas = db.Misijas.Find(id);
            if (misijas == null)
            {
                return HttpNotFound();
            }
            return View(misijas);
        }

        // POST: /Misijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Misijas misijas = db.Misijas.Find(id);
            db.Misijas.Remove(misijas);
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

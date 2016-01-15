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
    public class PlanetaController : Controller
    {
        private AstroEntities db = new AstroEntities();

        // GET: /Planeta/
        public ActionResult Index()
        {
            return View(db.Panetas.ToList());
        }

        // GET: /Planeta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paneta paneta = db.Panetas.Find(id);
            if (paneta == null)
            {
                return HttpNotFound();
            }
            return View(paneta);
        }

        // GET: /Planeta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Planeta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nosaukums,Vid_att_no_Saules,Vid_Radiuss__atiec_pret_zemi,Tilpums__attiec_pret_zemi,Masa,Blivums,Gravitacija_uz__ekvatora,Otrias_kos_atrums,Rotacijas_periods,Aprink_periods,Vid_orbitalais_atrums,Virsmas_vid_temp,Vid_temp,Atmosferas_sastavs,Dab_pavadoni,Gredzeni,Apraksts")] Paneta paneta)
        {
            if (ModelState.IsValid)
            {
                db.Panetas.Add(paneta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paneta);
        }

        // GET: /Planeta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paneta paneta = db.Panetas.Find(id);
            if (paneta == null)
            {
                return HttpNotFound();
            }
            return View(paneta);
        }

        // POST: /Planeta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nosaukums,Vid_att_no_Saules,Vid_Radiuss__atiec_pret_zemi,Tilpums__attiec_pret_zemi,Masa,Blivums,Gravitacija_uz__ekvatora,Otrias_kos_atrums,Rotacijas_periods,Aprink_periods,Vid_orbitalais_atrums,Virsmas_vid_temp,Vid_temp,Atmosferas_sastavs,Dab_pavadoni,Gredzeni,Apraksts")] Paneta paneta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paneta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paneta);
        }

        // GET: /Planeta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paneta paneta = db.Panetas.Find(id);
            if (paneta == null)
            {
                return HttpNotFound();
            }
            return View(paneta);
        }

        // POST: /Planeta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paneta paneta = db.Panetas.Find(id);
            db.Panetas.Remove(paneta);
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

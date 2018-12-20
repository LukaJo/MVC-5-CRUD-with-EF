using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_5_CRUD_with_EF.Models;

namespace MVC_5_CRUD_with_EF.Controllers
{
    public class ZaposlenisController : Controller
    {
        private ZaposleniEntities db = new ZaposleniEntities();

        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        // GET: Zaposlenis
        public ActionResult Index()
        {
            return View(db.Zaposlenis.ToList());
        }

        // GET: Zaposlenis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
               // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaposleni zaposleni = db.Zaposlenis.Find(id);
            if (zaposleni == null)
            {
                return HttpNotFound();
                
            }
            return View(zaposleni);
        }

        // GET: Zaposlenis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zaposlenis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RadnikID,Ime,Godine,Sektor,Grad")] Zaposleni zaposleni)
        {
            if (ModelState.IsValid)
            {
                db.Zaposlenis.Add(zaposleni);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zaposleni);
        }

        // GET: Zaposlenis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaposleni zaposleni = db.Zaposlenis.Find(id);
            if (zaposleni == null)
            {
                return HttpNotFound();
            }
            return View(zaposleni);
        }

        // POST: Zaposlenis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RadnikID,Ime,Godine,Sektor,Grad")] Zaposleni zaposleni)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zaposleni).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zaposleni);
        }

        // GET: Zaposlenis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaposleni zaposleni = db.Zaposlenis.Find(id);
            if (zaposleni == null)
            {
                return HttpNotFound();
            }
            return View(zaposleni);
        }

        // POST: Zaposlenis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zaposleni zaposleni = db.Zaposlenis.Find(id);
            db.Zaposlenis.Remove(zaposleni);
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

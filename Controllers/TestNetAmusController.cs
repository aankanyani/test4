using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using test4.Models;

namespace test4.Controllers
{
    public class TestNetAmusController : Controller
    {
        private UsersContext db = new UsersContext();

        // GET: TestNetAmus
        public ActionResult Index()
        {
            return View(db.TestNetAmus.ToList());
        }

        // GET: TestNetAmus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestNetAmu testNetAmu = db.TestNetAmus.Find(id);
            if (testNetAmu == null)
            {
                return HttpNotFound();
            }
            return View(testNetAmu);
        }

        // GET: TestNetAmus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestNetAmus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,surname")] TestNetAmu testNetAmu)
        {
            if (ModelState.IsValid)
            {
                db.TestNetAmus.Add(testNetAmu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testNetAmu);
        }

        // GET: TestNetAmus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestNetAmu testNetAmu = db.TestNetAmus.Find(id);
            if (testNetAmu == null)
            {
                return HttpNotFound();
            }
            return View(testNetAmu);
        }

        // POST: TestNetAmus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,surname")] TestNetAmu testNetAmu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testNetAmu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testNetAmu);
        }

        // GET: TestNetAmus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestNetAmu testNetAmu = db.TestNetAmus.Find(id);
            if (testNetAmu == null)
            {
                return HttpNotFound();
            }
            return View(testNetAmu);
        }

        // POST: TestNetAmus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestNetAmu testNetAmu = db.TestNetAmus.Find(id);
            db.TestNetAmus.Remove(testNetAmu);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentApplicationsController : Controller
    {
        private NominationFormEntities db = new NominationFormEntities();

        // GET: StudentApplications
        public ActionResult Index()
        {
            return View(db.StudentApplications.ToList());
        }

        // GET: StudentApplications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentApplication studentApplication = db.StudentApplications.Find(id);
            if (studentApplication == null)
            {
                return HttpNotFound();
            }
            return View(studentApplication);
        }

        // GET: StudentApplications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentApplications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,timestamp,name,email,currentSchool,eligible,age,phoneNumber,graduationDate")] StudentApplication studentApplication)
        {
            if (ModelState.IsValid)
            {
                studentApplication.timestamp = DateTime.Now;
                db.StudentApplications.Add(studentApplication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentApplication);
        }

        // GET: StudentApplications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentApplication studentApplication = db.StudentApplications.Find(id);
            if (studentApplication == null)
            {
                return HttpNotFound();
            }
            return View(studentApplication);
        }

        // POST: StudentApplications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,timestamp,name,email,currentSchool,eligible,age,phoneNumber,graduationDate")] StudentApplication studentApplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentApplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentApplication);
        }

        // GET: StudentApplications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentApplication studentApplication = db.StudentApplications.Find(id);
            if (studentApplication == null)
            {
                return HttpNotFound();
            }
            return View(studentApplication);
        }

        // POST: StudentApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentApplication studentApplication = db.StudentApplications.Find(id);
            db.StudentApplications.Remove(studentApplication);
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
